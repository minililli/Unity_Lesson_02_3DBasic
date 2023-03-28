using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputAction inputAction;
    Animator anim;
    Rigidbody rigid;
    public Rigidbody Rigid => rigid; //get만 있는 프로퍼티
    /// <summary>
    /// 이동속도
    /// </summary>
    public float currentMoveSpeed;
    public float moveSpeed = 5.0f;
    /// <summary>
    /// 회전속도
    /// </summary>
    public float rotateSpeed = 180;
    /// <summary>
    /// 점프력
    /// </summary>
    public float jumpForce = 5.0f;

    public float jumpCoolTime = 5.0f;
    public float jumpCoolTimeMax = 5.0f;

    private float JumpCoolTime
    {
        get => jumpCoolTime;
        set
        {
            jumpCoolTime = value;
            if(jumpCoolTime < 0)
            {
                jumpCoolTime = 0.0f;
            }
            onJumpCoolTimeChange?.Invoke(jumpCoolTime/jumpCoolTimeMax);
                 
        }
    }
           

    Action<float> onJumpCoolTimeChange;
    //true면 점프쿨타임 끝나서 점프 가능함, false 면 점프 쿨타임중
    private bool IsJumpCoolEnd => jumpCoolTime <= 0;
    /// <summary>
    /// 현재이동방향, -1 아래, +1 위
    /// </summary>
    float moveDir = 0;
    /// <summary>
    /// 현재회전방향, -1(좌), +1(우)
    /// </summary>
    float rotateDir = 0;
    /// <summary>
    /// 현재점프여부 true면 점프 중, false면 점프 중이 아님
    /// </summary>
    bool isJumping= false;
    /// <summary>
    /// 플레이어가 사망했음을 알리는 델리게이트
    /// </summary>
    public Action onDie;
    public Action<float> onLifeTimeChange;
    
    bool isAlive = true;

    public float lifeTimeMax = 3.0f;
    float lifeTime = 3.0f;

    public float LifeTime
    {
        get => lifeTime;
        private set
        {
            lifeTime = value;
            onLifeTimeChange?.Invoke(lifeTime/lifeTimeMax);
            if (lifeTime <= 0.0f)
            {
                Die();
            }
        }
    }


    private void Awake()
    {
        inputAction = new PlayerInputAction();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //아이템 사용알람이 울리면 실행될 함수 등록
        ItemUseAlarm alarm = GetComponentInChildren<ItemUseAlarm>();
        alarm.onUseableItemUsed += UseObject;
    }

    private void Start()
    {
       VirtualStick stick = FindObjectOfType<VirtualStick>();
       //stick.onMoveInput += (input) => SetInput(input, input != Vector2.zero);

        VirtualButton button = FindObjectOfType<VirtualButton>();
        button.onClick += Jump;
        onJumpCoolTimeChange?.Invoke(jumpCoolTime / jumpCoolTimeMax);
    
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();                           // Player 액션맵 활성화
        inputAction.Player.Move.performed += OnMoveInput;      // 액션들에게 함수 바인딩하기
        inputAction.Player.Move.canceled += OnMoveInput;       
        inputAction.Player.Use.performed += OnUseInput;
        inputAction.Player.Jump.performed += OnJumpInput;

        isAlive = true;
        LifeTime = lifeTimeMax;
        JumpCoolTime = 0.0f;
        ResetMoveSpeed();
    }
 
    private void OnDisable()
    {
        inputAction.Player.Jump.performed -= OnJumpInput;      //액션에 연결된 함수들 바인딩해제
        inputAction.Player.Use.performed -= OnUseInput;
        inputAction.Player.Move.canceled -= OnMoveInput;
        inputAction.Player.Move.performed -= OnMoveInput;
        inputAction.Player.Disable();                          //Player 액션맵 활성화
    }
    private void Update() // 다른 모든 업데이트가 실행되고 나서 실행되는 업데이트 (카메라처리)
    {
        LifeTime -= Time.deltaTime;     
    }

    private void FixedUpdate() //일정시간 간격으로 업데이트 (물리적처리)
    {
        Move();      //이동처리
        Rotate();   //회전처리

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  //Ground와 충돌했을 때만
        {
            OnGrounded();                                 //착지함수 실행
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            OnGrounded();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Platform")))
        {
            Platform platform = other.gameObject.GetComponent<Platform>();
            platform.onMove += OnRideMovingObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Platform platform = other.gameObject.GetComponent<Platform>();
            platform.onMove -= OnRideMovingObject;
        }
    }

    private void OnMoveInput(InputAction.CallbackContext context)   //현재 키보드 입력상황 받기
    {
        Vector2 input = context.ReadValue<Vector2>();
        rotateDir = input.x; //좌:-1, 우:+1
        moveDir = input.y; //앞:+1, 뒤:-1
        //Debug.Log(input);
        /*if(context.performed)
        {
            Debug.Log("Performed");
        }

        if(context.canceled)
        {
            Debug.Log("Canceled");
        }*/

        //context.performed : 액션에 연결된 키 중 하나라도 입력 중이면 true, 아니면 false;
        //context.percanceled : 액션에 연결된 키가 모두 입력중이지 않으면 true, 아니면 false;
        // 동시에 양방향 눌른다면? -1 1 일텐데, 왜 움직이는가?

        anim.SetBool("IsMove",true);
        anim.SetBool("IsMove", !context.canceled);                // 애니메이션 파라미터 변경(Idle,Move중 선택)

    }

    void OnUseInput(InputAction.CallbackContext context)
    {
        anim.SetTrigger("Use");
    }
    void Move()
    {
        rigid.MovePosition(rigid.position + Time.fixedDeltaTime * currentMoveSpeed * moveDir * transform.forward);

        anim.SetBool("IsMove", true);
    }

    void Rotate()
    {
        //회전 설정
        //rigid.AddToken();
        //rigid.MoveRotation();
        //Quaternion rotate = Quaternion.Euler(0, Time.fixedDeltaTime * rotateSpeed * rotateDir, 0);
        Quaternion rotate = Quaternion.AngleAxis(                               //특정 축을 기준으로 회전하는 쿼터니언을 만드는 함수
            Time.fixedDeltaTime * rotateSpeed * rotateDir, transform.up);       //플레이어의 up방향을 기준으로 회전
        rigid.MoveRotation(rigid.rotation * rotate);
        anim.GetBool("IsMove");
    }
  
    private void OnJumpInput(InputAction.CallbackContext context)
    {

        Jump();
    }
    /// <summary>
    /// 점프처리함수
    /// </summary>
    void Jump()
    {
        if(!isJumping && IsJumpCoolEnd)          // 점프중이 아니고 쿨타임이 다 되었을 때만 가능
        {
            JumpCoolTime = jumpCoolTimeMax;
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  //월드의 Up방향으로 힘을 즉시 가하기
            isJumping = true;
        }
    }


    private void OnGrounded()
    {
        isJumping = false;
    }
    /// <summary>
    /// 아이템 사용한다는 알람이 오면 실행되는 함수
    /// </summary>
    /// <param name="obj">사용할 오브젝트</param>
    private void UseObject(IUseableObject obj)
    {
        obj.Used();
    }

    public void Die()
    {
        if (isAlive)
        {
            anim.SetTrigger("Die");

            inputAction.Player.Disable();
            //pitch와 roll회전이 막혀있던 것을 풀기
            rigid.constraints = RigidbodyConstraints.None;

            //머리 위치에 플레이어의 뒷방향으로 0.5만큼의 힘을 가하기
            Transform head = transform.GetChild(1);
            rigid.AddForceAtPosition(-transform.forward * 0.5f, head.position);

            rigid.AddTorque(transform.up * 1.0f, ForceMode.Impulse);

            //델리게이트로 알림보내기
            onDie?.Invoke();
            isAlive = false;
        }
    
    }

    public void SetHalfSpeed()
    {
        currentMoveSpeed = moveSpeed * 0.5f;
    }

    public void ResetMoveSpeed()
    {
        currentMoveSpeed = moveSpeed;
    }

    private void OnRideMovingObject(Vector3 delta)
    {
        rigid.MovePosition(rigid.position + delta);
    }

    public void SetForceJumpMode()
    {
        isJumping = true;
    }
}

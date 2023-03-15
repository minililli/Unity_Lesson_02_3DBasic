using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputActions inputActions;
    Animator anim;
    Rigidbody rigid;

    public float moveSpeed = 5;
    public float rotateSpeed = 180;
    float moveDir = 0;
    float rotateDir = 0;
    bool isMove = false;

    

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMoveInput; //performed, ,canceled
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Use.performed += OnUseInput;
        inputActions.Player.Jump.performed += OnJumpInput;
        
    }
    private void OnDisable()
    {
        inputActions.Player.Jump.performed -= OnJumpInput;
        inputActions.Player.Use.performed -= OnUseInput;
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Move.performed -= OnMoveInput;
        inputActions.Player.Disable();
    }

    private void Update() 
    {

    }


    private void FixedUpdate() //일정시간 간격으로 업데이트 (물리적처리)
    {
        Move();
        Rotate();

    }

    //private void LateUpdate() // 다른 모든 업데이트가 실행되고 나서 실행되는 업데이트 (카메라처리)
    //{
    //    
    //}


    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        rotateDir = input.x; //좌:-1, 우:+1
        moveDir = input.y; //앞:+1, 뒤:-1
        //Debug.Log(input);
        anim.SetBool("IsMove",true);
       //context.canceled = anim.SetBool("IsMove", false);

    }

    void Move()
    {
        rigid.MovePosition(rigid.position + Time.fixedDeltaTime * moveSpeed * moveDir * transform.forward);
        
        anim.GetBool("IsMove");
    }

    void Rotate()
    {
        //회전 설정
        //rigid.AddToken();
        //rigid.MoveRotation();
        //Quaternion rotate = Quaternion.Euler(0, Time.fixedDeltaTime * rotateSpeed * rotateDir, 0);
        Quaternion rotate = Quaternion.AngleAxis(Time.fixedDeltaTime * rotateSpeed * rotateDir, transform.up);
        rigid.MoveRotation(rigid.rotation * rotate);
        anim.GetBool("IsMove");
    }
    private void OnUseInput(InputAction.CallbackContext obj)
    {

    }
    private void OnJumpInput(InputAction.CallbackContext obj)
    {

    }

}

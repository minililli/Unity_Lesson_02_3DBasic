using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WayPointUser : MonoBehaviour
{   /// <summary>
    /// 이 오브젝트가 움직일 웨이포인트 (반드시 설정되어야함)
    /// </summary>
    public WayPoint targetWayPoints;
    /// <summary>
    /// 이동속도
    /// </summary>
    public float moveSpeed = 1.0f;

    public Action<Vector3> onMove;

    /// <summary>
    /// 이번프레임이 이동한 정도
    /// </summary>
    protected Vector3 moveDelta = Vector3.zero;

    protected Vector3 moveDir;

    protected Transform target;
    Player player;

    
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    protected virtual void Start()
    {
        SetTarget(targetWayPoints.CurrentWayPoint);
    }
    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        moveDelta = Time.fixedDeltaTime * moveSpeed * moveDir;
        transform.Translate(moveDelta, Space.World);
        
        if ((target.position - transform.position).sqrMagnitude < 0.01f) //거리가 0.1보다 작을때, (거리 < 0.1), (거리의 제곱<0.1의 제곱) 둘의 결과는 같다.
        {
            SetTarget(targetWayPoints.GetNextWayPoint());                //도착했으면 다음 웨이포인트 지점 가져와서 설정하기
            moveDelta = Vector3.zero;
            OnArrived();
        }
        onMove?.Invoke(moveDelta);
    }

    /// <summary>
    /// 다음 웨이포인트 지정하는 함수
    /// </summary>
    /// <param name="target">다음 웨이포인트의 트랜스폼</param>
    protected virtual void SetTarget(Transform target)    
    {
        this.target = target;           //목적지 설정하고
        moveDir = (this.target.position - transform.position).normalized;
    }
    protected virtual void OnArrived()
    {

    }


}

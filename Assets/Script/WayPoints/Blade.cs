using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : WayPointUser
{

    Transform bladeMesh;
    /// <summary>
    /// 회전속도
    /// </summary>
    public float spinSpeed = 720.0f;

    private void Awake()
    {
        bladeMesh = transform.GetChild(0);
    }

    protected override void Start()
    {
        SetTarget(targetWayPoints.CurrentWayPoint);
        
    }

    private void Update()
    {
        bladeMesh.Rotate(Time.deltaTime * spinSpeed * Vector3.right);
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        player.Die();
    }

    protected override void SetTarget(Transform target)
    {
        base.SetTarget(target);
        transform.LookAt(target);
    }
}

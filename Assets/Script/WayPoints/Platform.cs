using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : WayPointUser
{
    private void FixedUpdate()
    {
        Move();
    }
    protected override void SetTarget(Transform target)
    {
        base.SetTarget(target);
        Vector3 lookposition = target.position;
        lookposition.y = transform.position.y;
        //transform.LookAt(lookposition);
    }
  
}

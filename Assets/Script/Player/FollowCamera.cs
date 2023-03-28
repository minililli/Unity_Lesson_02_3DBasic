using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    float speed= 0.5f;
    
    private void Start()
    {
        if(target==null)
        {
            Player player = FindObjectOfType<Player>();
            target = player.transform;
        }
        offset = (transform.position - target.position);

        
       // Quaternion deltaAngle = Quaternion.FromToRotation(transform.position, target.position);
       // transform.rotation *= deltaAngle;

    }

    private void FixedUpdate()
    {

        //transform.rotation = Quaternion.LookRotation(target.forward);
        transform.rotation *= Quaternion.Euler(0, Quaternion.Angle(transform.rotation, target.rotation), 0);
        transform.position = target.position + offset;
        //transform.rotation = Quaternion.AngleAxis(, Vector3.up);
    }
}

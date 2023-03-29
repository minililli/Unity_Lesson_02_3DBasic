using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    float speed= 0.5f;
    float offsetLength;
    
    private void Start()
    {
        if(target==null)
        {
            Player player = FindObjectOfType<Player>();
            target = player.transform.GetChild(8);      //cameraRoot가 바라보는 대상
        }
        offset = (transform.position - target.position);
        offsetLength = offset.magnitude;
        
       // Quaternion deltaAngle = Quaternion.FromToRotation(transform.position, target.position);
       // transform.rotation *= deltaAngle;

    }

    private void FixedUpdate()
    {
        //호를 그리면서 움직이게 만들기(Slerp)
        transform.position = Vector3.Slerp(transform.position, //현재위치에서
                                           target.position + Quaternion.LookRotation(target.forward) * offset, //offset만큼 떨어진 위치로
                                           Time.fixedDeltaTime * speed);     //TimefixedDletaTime * speed 만큼 보간

        //transform.rotation = Quaternion.LookRotation(target.forward);
        //transform.rotation *= Quaternion.Euler(0, Quaternion.Angle(transform.rotation, target.rotation), 0);
        //transform.rotation = Quaternion.AngleAxis(, Vector3.up);

        transform.LookAt(target); //카메라가 목표지점 바라보기

        Ray ray = new Ray(target.position, transform.position - target.position);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, offsetLength))
        {
            transform.position = hitinfo.point;                        // hitinfo.point = 충돌한 지점
        }

    }
}

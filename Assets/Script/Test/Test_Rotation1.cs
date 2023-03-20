using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Rotation1 : TestBase
{
    public Transform objBase;
    public Transform objChild1;
    public Transform objChild2;
    private void Start()
    {
        Quaternion q = Quaternion.identity;
        q= Quaternion.Euler(0,0,0);
        objChild2.rotation = q;
    }

    protected override void Test1(InputAction.CallbackContext _)
    {
        Quaternion q = Quaternion.identity;
        objBase.rotation = q;
        objChild1.rotation = q;
        objChild2.rotation = Quaternion.Euler(0, 90, 0);
    }
    protected override void Test2(InputAction.CallbackContext _)
    {   
        // .LookRotation : 특정방향을 바라보는 회전을 만든다.
        //Quaternion.LookRotation(방향벡터)

        //objChild1이 월드의 위를 바라보게 만들기
        //objChild1.rotation = Quaternion.LookRotation(Vector3.up);

        //objChild1이 월드의 위를 바라보고 objChild1의 위쪽 방향은 월드의 오른쪽으로 설정하기
        objChild1.rotation = Quaternion.LookRotation(Vector3.right);
    } 
    protected override void Test3(InputAction.CallbackContext _)
    {   
        //두 회전의 사이각 구하기(a회전에서 b회전으로 가는데 필요한 각구하기) 
       float angle = Quaternion.Angle(objChild1.rotation, objChild2.rotation);
        Debug.Log($"Angle:{angle}");

    }
    protected override void Test4(InputAction.CallbackContext _)
    {
        // .AngleAxis : 특정축(자신의 로컬기준)을 기준으로 회전을 시키는 함수
        //objChild2.rotation = Quaternion.AngleAxis(45, Vector3.forward);

        //objChild2의 원래 회전에 추가로 z축으로 45도만큼 더 회전시키기
        //objChild2.rotation = objChild2.rotation * Quaternion.AngeAxis(45,Vector3.forward);
        objChild2.rotation *= Quaternion.AngleAxis(45, Vector3.forward);
    }
    protected override void Test5(InputAction.CallbackContext _)
    {
        // .FromToRotation() : 시작방향에서 도착방향으로 바라보게 만드는 함수
        objBase.rotation *= Quaternion.FromToRotation(objBase.forward, objChild2.forward);
    }




}

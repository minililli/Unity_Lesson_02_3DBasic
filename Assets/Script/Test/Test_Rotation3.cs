using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Rotation3 : TestBase
{
    public Transform objBase;
    public Transform objChild1;
    public Transform objChild2;
    private void Update()
    {
        //y축으로 1초에 180도 회전
        //objBase.Rotate(0, Time.deltaTime * 180.0f, 0);
        //objBase.Rotate(new Vector3(0, Time.deltaTime * 180, 0));
        //objBase.Rotate(transform.up, Time.deltaTime * 180, 0); // 자기 자신의 y축 기준으로 180도 회전
        //objBase.Rotate(Vector3.up, Time.deltaTime * 180f); //로컬기준
        //objBase.Rotate(Vector3.up, Time.deltaTime * 180f,Space.World); //월드기준
        //objBase.Rotate(Vector3.up, Time.deltaTime * 180f,Space.Self); //로컬기준

        objBase.RotateAround(new Vector3(0, 0, 5), Vector3.right, Time.deltaTime*180.0f);

    }


}
        
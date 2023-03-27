using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManual : Platform, IUseableObject
{

    /// <summary>
    /// 플랫폼이 현재 움직임여부를 설정하는 변수. true면 움직이고, false면 안움직인다.
    /// </summary>
    bool isMoving = false;
    
    /// <summary>
    /// private 프로퍼티. 내부에서 isMoving이 변경될 때 실행될 함수 적용
    /// </summary>
    bool IsMoving
    {
        get => isMoving;
        set
        {
            if(isMoving)
            {
                ActivatePlatform();
            }
            else
            {
                DeActivatePlatform();
            }
        }
    }
    /// <summary>
    /// Interface의 직접/간접 사용여부 - 간접사용임
    /// </summary>
    public bool isDirectUse => false;

    /// <summary>
    /// isMoving이 true이면 Move() 실행
    /// </summary>
    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move(); 
        }

    }
    /// <summary>
    /// 움직이기 시작할 때 실행될 함수
    /// </summary>
    public void ActivatePlatform()
    {
    }
    /// <summary>
    /// 정지시킬 때 실행될 함수
    /// </summary>
    public void DeActivatePlatform()
    {     
    }
    /// <summary>
    /// 아이템을 사용하면 실행되는 함수
    /// </summary>
    public void Used()
    {
        IsMoving = !IsMoving;   //isMoving만 반대로 변경
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_CineMachine : TestBase
{
    CinemachineVirtualCamera[] vcams;

    private void Start()
    {
        if(vcams==null)
        {
            vcams = FindObjectsOfType<CinemachineVirtualCamera>();
        }
    }

    protected override void Test1(InputAction.CallbackContext _)
    {
        
    }
    protected override void Test2(InputAction.CallbackContext _)
    {
        
            vcams[1].Priority = 100;
    }

   /* void ResetPriority()
    {
        foreach (var vcma in vcams)
        {
            vcams
        }
    }   */
}

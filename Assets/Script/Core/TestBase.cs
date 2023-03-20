using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBase : MonoBehaviour
{
    protected PlayerInputAction InputAction;
    protected void Awake()
    {
        InputAction = new PlayerInputAction();
    }

    protected virtual void OnEnable()
    {
        InputAction.Test.Enable();
        InputAction.Test.Test1.performed += Test1;
        InputAction.Test.Test2.performed += Test2;
        InputAction.Test.Test3.performed += Test3;
        InputAction.Test.Test4.performed += Test4;
        InputAction.Test.Test5.performed += Test5;
    }

    protected virtual void OnDisable()
    {
        InputAction.Test.Test5.performed -= Test5;
        InputAction.Test.Test4.performed -= Test4;
        InputAction.Test.Test3.performed -= Test3;
        InputAction.Test.Test2.performed -= Test2;
        InputAction.Test.Test1.performed -= Test1;
        InputAction.Test.Disable();

    }

    protected virtual void Test1(InputAction.CallbackContext _)
    {
        
    }
    protected virtual void Test2(InputAction.CallbackContext _)
    {

    }
    protected virtual void Test3(InputAction.CallbackContext _)
    {

    }
    protected virtual void Test4(InputAction.CallbackContext _)
    {

    }
    protected virtual void Test5(InputAction.CallbackContext _)
    {

    }    
}

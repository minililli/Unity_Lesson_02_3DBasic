using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Earth : MonoBehaviour
{
    public Transform sun;

    private void Update()
    {
        transform.RotateAround(sun.position, sun.up, Time.deltaTime * 360.0f);
    }
}

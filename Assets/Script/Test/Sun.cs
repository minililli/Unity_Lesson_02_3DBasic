using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Transform sun;

    private void Awake()
    {
        sun = GetComponent<Transform>();
    }

    private void Update()
    {
        
    }
}

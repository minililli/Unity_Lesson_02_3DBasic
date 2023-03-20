using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    GameObject Sun;
    /* private void Update()
     {
         //transform.LookAt(sun);
         //transform.rotation = Quaternion.LookRotation(sun.position - transform.position);

         //특정지점에 하나의 축을 세우고 그 축을 기준으로 회전시키기
         //transform.RotateAround(sun.position, sun.up, Time.deltaTime* 360.0f);
     }   */
    private void Awake()
    {
        GameObject obj = GameObject.Find("Sun");
        FindObjectOfType<Sun>();
    }

    private void Update()
    {
        transform.RotateAround(FindObjectOfType<Sun>().transform.position, FindObjectOfType<Sun>().transform.up, Time.deltaTime * 360);
    }


}

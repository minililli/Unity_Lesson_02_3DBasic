using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    /// <summary>
    /// 발사할 총알 프리팹
    /// </summary>
    public GameObject bulletPrefab;
    /// <summary>
    /// 총알 발사 시간간격
    /// </summary>
    public float fireInterval = 0.5f;
    /// <summary>
    /// 총알 발사되는 Transform
    /// </summary>
    protected Transform fireTransform;
    /// <summary>
    /// 총몸의 트랜스폼
    /// </summary>
    protected Transform barrelBodyTransform;

    /// <summary>
    /// 총알을 계속 발사하는 코루틴
    /// </summary>
    protected IEnumerator fireCoroutine;
    /// <summary>
    /// 총알 발사 시간 간격만큼 기다리는 WaitForSeconds
    /// </summary>
    protected WaitForSeconds waitFireInterval;

    protected virtual void Awake()
    {
        barrelBodyTransform = transform.GetChild(0);                    //BarrelBody
        fireTransform = barrelBodyTransform.transform.GetChild(1);      //fireTransform
        fireCoroutine = PeriodFire();
    }

    protected virtual void Start()
    {
        waitFireInterval = new WaitForSeconds(fireInterval);
    }

    /// <summary>
    /// 총알을 주기적으로 발사하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator PeriodFire()
    {
        while (true)
        {
            yield return waitFireInterval;
            OnFire();
        }
    }

    /// <summary>
    /// 총알을 한발 발사하는 함수
    /// </summary>
    protected virtual void OnFire()
    {

    }

}

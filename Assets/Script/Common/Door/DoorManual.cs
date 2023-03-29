using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorManual : DoorBase, IUseableObject
{
    /// <summary>
    /// 자동으로 닫힐때까지 걸리는 시간
    /// </summary>
    public float closeTime = 3.0f;

    /// <summary>
    /// 코루틴용으로 한번만 만들어 놓고 재사용하기 위한 용도
    /// </summary>
    WaitForSeconds closeWait;

    TextMeshPro text;
    public bool IsDirectUse => true;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        closeWait = new WaitForSeconds(closeTime);
        text.gameObject.SetActive(false);
    }
    /// <summary>
    /// 이 오브젝트가 실행되는 함수
    /// </summary>
    public void Used()
    {
        //Debug.Log("사용됨");
        Open();                           //문열고
        StartCoroutine(AutoClose());        //자동으로 닫히게
    }

    IEnumerator AutoClose()
    {
        yield return closeWait;             //closeTime초만큼 대기하고
        Close();                          //문닫기
    }

    private void OnTriggerEnter(Collider other)
    {

        text.gameObject.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}

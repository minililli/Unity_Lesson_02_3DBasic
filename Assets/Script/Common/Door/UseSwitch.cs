using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSwitch : MonoBehaviour, IUseableObject
{
    /// <summary>
    /// 사용할 오브젝트
    /// </summary>
    public GameObject target;
    /// <summary>
    /// 사용할 오브젝트가 가지고 있는 IUseableObject 인터페이스
    /// </summary>
    IUseableObject useTarget;
    /// <summary>
    /// 사용중인지 표시하는 플래그
    /// </summary>
    bool isUsed = false;
    
    Animator anim;

    public bool IsDirectUse => true;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        useTarget = target.GetComponent<IUseableObject>();

        if (useTarget == null)
        {
            Debug.Log("Target이 설정되지 않았습니다.");
        }

    }
    public void Used()
    {
        if(useTarget != null)
        {
            if (!isUsed)
            {
                useTarget.Used();
                StartCoroutine(ResetSwitch());
            }
            
        }

    }

    IEnumerator ResetSwitch()
    {
        isUsed = true;
        anim.SetBool("IsOpen", isUsed);
        yield return new WaitForSeconds(1);
        isUsed = false;
        anim.SetBool("IsOpen", isUsed);
    }
}

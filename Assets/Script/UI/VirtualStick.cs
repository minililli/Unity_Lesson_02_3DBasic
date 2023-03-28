using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class VirtualStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    /// <summary>
    /// 가상 스틱의 입력을 알리는 델리게이트
    /// </summary>
    public Action<Vector2> onMoveInput;
    /// <summary>
    /// 전체 영역의 Recttransform
    /// </summary>
    RectTransform handleRect;
    /// <summary>
    /// handle의 Recttransform
    /// </summary>
    RectTransform containerRect;
    /// <summary>
    /// handle이 움직일 수 있는 최대 거리
    /// </summary>
    float stickRange;

    void Awake()
    {
        containerRect = transform as RectTransform;
        Transform child = transform.GetChild(0);
        handleRect = child as RectTransform;        //handleRect = child.GetComponent<RectTransform>(); 보다는 child as RectTransform이 나은듯.
        stickRange = (containerRect.rect.width - handleRect.rect.width) * 0.5f;
    }
    /// <summary>
    /// 스틱의 움직임을입력으로 변경
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //containerRect의 피봇에서 얼만큼 이동했는지가 position에 들어간다.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position,
        eventData.pressEventCamera, out Vector2 position);

        position = Vector2.ClampMagnitude(position, stickRange);        //움직임이 stickRange를 넘지 않도록 클램프

        handleRect.anchoredPosition = position;

        InputUpdate(position);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //OnPointerUp때문에 넣은 것. 없으면 OnPointerUp이 실행되지 않는다.
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputUpdate(Vector2.zero);  ///마우스를 땠을 떄 핸들 중립 위치로 초기화
    }
/// <summary>
/// 스틱의 움직ㅇ미을 입력으로 변경해서 핸들을 움직이고 신호를 보내는 함수/
/// </summary>
/// <param name="pos">움직인 양</param>
    void InputUpdate(Vector2 pos)
    {
        handleRect.anchoredPosition = pos;      //앵커에서 pos만큼 이동.
        onMoveInput?.Invoke(pos / stickRange);  //입력 신호 보내기 (범위는 -1~ 1)
        Debug.Log(pos / stickRange);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    Transform[] waypoints;

    int index=0;                    //현재 가고 있는 웨이포인트의 인덱스(번호)
    /// <summary>
    /// 현재 향하고 있는 웨이포인트의 트랜스폼 확인용 프로퍼티
    /// </summary>
    public Transform CurrentWayPoint => waypoints[index];
    private void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for(int i =0; i< waypoints.Length; i++) 
        {
            waypoints[i]= transform.GetChild(i);
        }
    }

    public Transform GetNextWayPoint()
    {
        index++;                    //index 0~3까지만되어야한다.
        index %= waypoints.Length;  //indx 0~(waypoints.Length-1)까지만 되어야한다.
        return waypoints[index];    //해당 트랜스폼 리턴
    }


}

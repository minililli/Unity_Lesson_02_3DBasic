using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProduce : MonoBehaviour
{
    CinemachineVirtualCamera vCamera;
    CinemachineDollyCart dollyCart;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.onDie += produceStart;
        vCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        vCamera.LookAt = player.transform;
        dollyCart = GetComponentInChildren<CinemachineDollyCart>();

    }

    private void produceStart()
    {
        transform.position = player.transform.position;
        vCamera.Priority = 100;
        dollyCart.m_Speed = 10;
    }
}

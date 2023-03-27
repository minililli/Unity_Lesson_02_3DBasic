using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorTrap : DoorManual
{
    ParticleSystem ps;
    Player player;
    TextMeshPro text;
    protected override void Awake()
    {
        base.Awake();
        Transform child = transform.GetChild(2);
        ps = child.GetComponent<ParticleSystem>();
        text = GetComponentInChildren<TextMeshPro>();
    }
    protected override void OnOpen()
    {
        base.OnOpen();
        ps.Play();
        if(player != null)
        {
            player.Die();
        }

    }

    protected override void OnClose()
    {
        base.OnClose();
        ps.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(true);
        player = other.GetComponent<Player>();
    }

    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

}

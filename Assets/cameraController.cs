using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    GameObject player;
    public float posY;

    private void Start()
    {
        this.player = GameObject.Find("player");
    }

    private void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y + posY, transform.position.z);
    }
}

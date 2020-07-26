using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    GameObject player;
    GameObject player2;
    public float posY;

    private void Start()
    {
        this.player = GameObject.Find("player");
        this.player2 = GameObject.Find("player2");
    }

    private void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        Vector3 player2Pos = this.player2.transform.position;
        transform.position = new Vector3((playerPos.x + player2Pos.x) / 2, (playerPos.y + player2Pos.y) / 2 , transform.position.z);
    }
}

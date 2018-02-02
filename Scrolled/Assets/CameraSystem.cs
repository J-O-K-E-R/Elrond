using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject player;
    public float offset = 1.8f;
    public float offsetSmooth = 1.8f;
    private Vector3 playerPosition;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update() {
        playerPosition = player.transform.position;
        if (player.transform.localScale.x > 0f) {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        else {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        if(playerPosition.y < -0.74f) {
            transform.position = Vector3.Lerp(transform.position, new Vector3 (playerPosition.x, -0.74f, playerPosition.z), offsetSmooth * Time.deltaTime);
        }
        else {
            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmooth * Time.deltaTime);
        }
        
    }

}


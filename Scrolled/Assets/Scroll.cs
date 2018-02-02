using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float speed = 0.5f;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        transform.position = new Vector3(player.transform.position.x + 0.9f, transform.position.y, transform.position.z);
        GetComponent<SpriteRenderer>().material.mainTextureOffset = offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCloud : MonoBehaviour {

    public float speed;
    private GameObject cam;
    private GameObject player;
    // Use this for initialization
    void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        speed = 0.002f;
        Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;
        offset.x = Time.time * speed;//Vector2.Lerp(offset, new Vector2(Time.deltaTime * speed, 0), 1f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        transform.position = new Vector3(cam.transform.position.x + 0.9f, transform.position.y, transform.position.z);
    }
}

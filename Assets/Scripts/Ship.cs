using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    [SerializeField] float width;
    [SerializeField] float minX;
    [SerializeField] float maxX;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 shipPos = new Vector2(transform.position.x, transform.position.y);
        shipPos.x = Mathf.Clamp( Input.mousePosition.x / Screen.width * width, minX, maxX);
        transform.position = shipPos;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}

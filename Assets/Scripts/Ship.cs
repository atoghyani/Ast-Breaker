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
        shipPos.x = Mathf.Clamp( GetXPos(), minX, maxX);
        transform.position = shipPos;
	}


    private float GetXPos()
    {
        if(FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Mine>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * width;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}

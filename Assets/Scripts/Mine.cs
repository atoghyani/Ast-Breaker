using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {


    [SerializeField] Ship ship1;
    [SerializeField] float direction;
    [SerializeField] float force;


    bool hasStarted = false;

    Vector2 shipMineVector;
	// Use this for initialization
	void Start ()
    {
        shipMineVector = transform.position - ship1.transform.position;
	}
	
	// Update is called once per frame
    void Update ()
    {
        if(!hasStarted)
        {
            LockMineToShip();
        }
       
        LunchOnClick();

    }

    private void LunchOnClick()
    {
        if(Input.GetMouseButtonDown(0)&&!hasStarted)
        {
            GetComponent<AudioSource>().Play();

            GetComponent<Rigidbody2D>().velocity = new Vector2(direction, force);
            hasStarted = true;
        }
    }

    private void LockMineToShip()
    {
        Vector2 shipPos = new Vector2(ship1.transform.position.x, ship1.transform.position.y);
        transform.position = shipPos + shipMineVector;
    }

   
}

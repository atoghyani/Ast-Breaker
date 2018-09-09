
using UnityEngine;

public class Mine : MonoBehaviour {


    [SerializeField] Ship ship1;
    [SerializeField] float direction;
    [SerializeField] float force;
    [SerializeField] float randomFactor = 0.2f;

    Rigidbody2D rigidBody;


    bool hasStarted = false;

    Vector2 shipMineVector;
	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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

            rigidBody.velocity = new Vector2(direction, force);
            hasStarted = true;
        }
    }

    private void LockMineToShip()
    {
        Vector2 shipPos = new Vector2(ship1.transform.position.x, ship1.transform.position.y);
        transform.position = shipPos + shipMineVector;
    }

    private void nCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,randomFactor),
            Random.Range(0f, randomFactor));
        rigidBody.velocity += velocityTweak;
    }


}

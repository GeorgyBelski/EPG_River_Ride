using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed =10f;
    public float ctrlSpeed = 2f;
    [Range(3, 25)]
    public int maxFuel = 16;
    public int currentFuel;
    [Range(0.1f, 2.0f)]
    public float fuelUsingSpeed = 0.2f;
    float fuelUnit = 0f;

    public Bullet bulletPrefub;
    public Transform visualObject;
    public GameObject explosion;
    private bool life;
    private Rigidbody rb;
    public Vector3 checkPoint;

    void Start ()
    {
        checkPoint = this.transform.position;
        rb = GetComponent<Rigidbody>();
        life = true;
        currentFuel = maxFuel;
    }
	
	void Update ()
    {
        float control = Input.GetAxisRaw("Horizontal");
        float acceleration = Input.GetAxis("Vertical");
        transform.position += Vector3.right * Time.deltaTime * speed * control * ctrlSpeed;
        transform.position += Vector3.forward * Time.deltaTime * acceleration * ctrlSpeed;
        transform.position += transform.forward * Time.deltaTime * speed ;

        if (visualObject)
        {
            visualObject.transform.rotation = Quaternion.Euler(0f, 0f, control * -30f);
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && bulletPrefub)
        {
            Instantiate(bulletPrefub, this.transform.position, this.transform.rotation);

        }

        UsingOfFuel();

        if (speed == 0 && transform.position.y > -2.9f) {
            transform.position += Vector3.down * Time.deltaTime * 10;
            if (transform.position.y <= -2.9f)
                Debug.Log("Game Over ");
        }

        if (!life) {
            rb.detectCollisions = true;
            life = true;
        }

    }

    public void UsingOfFuel()
    {
            fuelUnit += Time.deltaTime * fuelUsingSpeed;
            if (fuelUnit >= 1f && currentFuel > 0)
            {
                currentFuel--;
              //  Debug.Log("currentFuel: "+currentFuel);
                fuelUnit = 0f;
            }
            if(currentFuel ==0)
            {
                speed = 0;
            }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player Collision: "+ collision.gameObject);

        if (life && collision.collider.gameObject.layer == 8) // Ground Layer
        {
            if(explosion)
                Instantiate(explosion, transform.position, transform.rotation);
            //Destroy(GetComponent<Rigidbody>());
            LoseLife();
        }
    }
    */
    public void LoseLife()
    {
        rb.detectCollisions = false;
        rb.velocity = Vector3.zero;
        this.transform.position = checkPoint;
        life = false;
    }

    private void OnTriggerEnter(Collider other)
    {
     //   Enemy enemy = other.GetComponent<Enemy>();
        if (other.gameObject.layer == 9) //Enemy Layer
        {
            Debug.Log("Player OnTriggerEnter Enemy");
            if (explosion)
                Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            LoseLife();
        }
    }
    private void MakeExplosion(Transform objectTransform)
    {
        if (explosion)
        {
            Instantiate(explosion, objectTransform.position, objectTransform.rotation);
            Destroy(gameObject);
        }
    }
}

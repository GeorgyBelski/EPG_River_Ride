using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 50f;

    public GameObject explosion;
    private float stert;
    public float lifeDistance = 20f;
    // Use this for initialization
    void Start() {
        stert = transform.position.z;
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * Time.deltaTime * speed;
        if(transform.position.z - stert >= lifeDistance)
        {
            Destroy(gameObject);
        }
            
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet OnCollisionEnter: "+ collision.gameObject);
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet OnTriggerEnter");


        //   Enemy enemy = other.GetComponent<Enemy>();
        //   ReFueling reFueling = other.GetComponentInParent<ReFueling>();

        bool hitEnemy = false;

        if (other.gameObject.layer == 9) {
            Player.score++;
            hitEnemy = true;
        }

        if (hitEnemy || other.gameObject.layer == 12)
        {
            Debug.Log("Bullet hits: " + other.gameObject);
            MakeExplosion(other.gameObject.transform);
            Destroy(other.gameObject.gameObject);
        }

    }
    private void MakeExplosion(Transform objectTransform) {
        if (explosion)
        {
            Instantiate(explosion, objectTransform.position, objectTransform.rotation);
            Destroy(gameObject);
        }
    }
}


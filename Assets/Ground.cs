using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public GameObject explosion;

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ground OnTriggerEnter: " + other.gameObject);
        

        if (other.gameObject.layer == 10) //Player Layer
        {
            Debug.Log("Player hits the Griund");
            MakeExplosion(other.transform);
            Player player = other.GetComponentInParent<Player>();
            player.LoseLife();
        }
     //   Bullet bullet = other.GetComponentInParent<Bullet>();
        if (other.gameObject.layer == 11) //Bullet Layer
        {
            Destroy(other.gameObject);
        }

    }
    private void MakeExplosion(Transform objectTransform)
    {
        if (explosion)
        {
            Instantiate(explosion, objectTransform.position, objectTransform.rotation);
         //   Destroy(gameObject);
        }
    }
}

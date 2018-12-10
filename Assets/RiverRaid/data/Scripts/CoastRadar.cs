using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoastRadar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == 8) //Graund Layer
        { 
            Enemy enemy = transform.parent.GetComponent<Enemy>();
            if(enemy)
                enemy.direction *= -1;
        }
    }
}

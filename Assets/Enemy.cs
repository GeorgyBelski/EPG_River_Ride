using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int direction = 1;
    public float speed = 10f;

    void Start () {
        float randomDirection = Random.Range(-1f, 1f);

        if (randomDirection > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
	}
	
	void Update ()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime * direction;
        this.transform.position = pos;   
    }




}

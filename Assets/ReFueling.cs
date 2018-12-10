using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFueling : MonoBehaviour {
    public float reFuelingSpeed = 5f;

    private Player player;

    float fuelUnit = 0f;

    void Start () {
		
	}
	
	void Update () {
        if (player)
        {
            fuelUnit += Time.deltaTime * reFuelingSpeed;
            if (fuelUnit >= 1 && player.currentFuel < player.maxFuel)
            { 
                player.currentFuel++;
             //   Debug.Log("reFuel: " + player.currentFuel);
                fuelUnit = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
          player = other.GetComponentInParent<Player>();
     //   Debug.Log(" start reFueling of Player");
        this.transform.localScale = new Vector3(2,1,2);
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
    //    Debug.Log(" end reFueling of Player");
        this.transform.localScale = new Vector3(1, 1, 2);
    }
}

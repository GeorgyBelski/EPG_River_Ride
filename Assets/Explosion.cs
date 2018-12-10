using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float factor = 1f;
    public new MeshRenderer renderer;

    Color32 col;

    void Start () {
        renderer = GetComponent<MeshRenderer>();

        col = renderer.material.GetColor("_Color");
    }
	
	void Update () {
        transform.localScale += Vector3.one * factor;
        if(col.a>100)
            col.a-=50;
        else if(col.a>=10)
            col.a -= 10;
        else
            col.a =0;
        renderer.material.SetColor("_Color", col);

        if (transform.localScale.x > 30) {
            Destroy(gameObject);
        }
	}
}

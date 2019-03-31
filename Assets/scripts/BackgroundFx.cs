using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFx : MonoBehaviour {


    private float speed;
    private float Xend;
    private float Xstart;

     void Start()
    {
        Xend = -19F;
        Xstart = 17.9F;
        speed = 4F;
    }

     void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < Xend) {
            Vector2 pos = new Vector2(Xstart, transform.position.y);
            transform.position = pos;
        } 
    }
}

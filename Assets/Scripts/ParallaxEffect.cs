using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Start is called before the first frame update

    public float Parallax;
    void Start()
    {
  
        GetComponent<Rigidbody2D>().velocity = Vector2.left * Parallax;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -30) transform.position = new Vector3(transform.position.x +60, transform.position.y, 0);
    }
}

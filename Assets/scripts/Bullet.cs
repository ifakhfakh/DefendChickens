using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        Destroy(this.gameObject);
    } 

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.name);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

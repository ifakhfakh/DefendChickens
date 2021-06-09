using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 2f;

    public bool switchRight;

    public bool switchBottom;
    public bool horizontalMouvement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       AnimatorControllerParameter[] list = GetComponent<Animator>().parameters ;
       foreach(AnimatorControllerParameter param in list) {
           if (param.name == "switchRight") {
                GetComponent<Animator>().SetBool("switchRight",switchRight);
           } else if (param.name == "switchBottom") {
               GetComponent<Animator>().SetBool("switchBottom",switchBottom);
           }
       }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() 
{      
    if (horizontalMouvement) {
        horientalMouvement();
    } else {
        verticalMouvement();
    }


}

void horientalMouvement() {
     if (!switchRight) {
        rb.velocity = new Vector3(-1,0,0) * speed;
    } else {
        rb.velocity = new Vector3(1,0,0) * speed;
    }
}

void verticalMouvement() {
     if (switchBottom) {
        rb.velocity = new Vector3(0,-1,0) * speed;
    } else {
        rb.velocity = new Vector3(0,1,0) * speed;
    }
}
    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("entered");

        if (col.gameObject.name=="leftFence") {
            switchRight = true;
            GetComponent<Animator>().SetBool("switchRight",true);
        } else if (col.gameObject.name=="rightFence") {
            switchRight = false;
            GetComponent<Animator>().SetBool("switchRight",false);
        } else if (col.gameObject.name=="topFence") {
            switchBottom = true;
            GetComponent<Animator>().SetBool("switchBottom",true);
        } 
        else if (col.gameObject.name=="bottomFence") {
            switchBottom = false;
            GetComponent<Animator>().SetBool("switchBottom",false);
        } 
    }
}

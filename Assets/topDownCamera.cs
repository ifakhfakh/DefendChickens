using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownCamera : MonoBehaviour
{

    public float height = 20.0f;
public float distance = 15.0f;
public Transform target ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        transform.position = new Vector3(transform.position.x,transform.position.y + height,transform.position.z-distance);
        transform.LookAt(target.position);
    }
}

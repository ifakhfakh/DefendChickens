using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leathal : MonoBehaviour
{
  
    public float damage;
    public string enemyTag; 

void OnTriggerEnter2D(Collider2D other){
	if(other.gameObject.tag == enemyTag){
        Debug.Log("hit");
		other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
	}
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

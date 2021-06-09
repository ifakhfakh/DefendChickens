using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
       const float MAXHEALTH = 100f;
    float health;

    public Image healthbar; 
    public Behaviour[] disableOnDeath;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;
    }

public void TakeDamage(float amount) {
	health -= amount;
    if (this.gameObject.tag=="Player") {
        Debug.Log("player hit");
        healthbar.fillAmount = health/MAXHEALTH;

    }

	if(health <= 0){
		health = 0;
		Die();
		}
}
void Die(){
	//Disable all the components inside the disableOnDeath array that you will assign from the inspector
    if (this.gameObject.tag=="Player") {
    text.text = "You died";
    text.gameObject.SetActive(true);
    Time.timeScale = 0;
    } else {
        Destroy(gameObject);
    }
	foreach(Behaviour behaviour in disableOnDeath)
	{
			behaviour.enabled = false;
	}
}


}

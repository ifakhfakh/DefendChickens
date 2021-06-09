using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckChcicken : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] chickens;

    public Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chickens = GameObject.FindGameObjectsWithTag("chicken");
        if (chickens.Length==0) {
            text.text = "All chickens have died";
            Time.timeScale = 0;
            text.gameObject.SetActive(true);
            
        }
    }
}

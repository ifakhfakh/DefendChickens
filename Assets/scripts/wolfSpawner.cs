using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject rightFence;
    public GameObject leftFence;

    public GameObject wolf;

    void Start()
    {
        InvokeRepeating("Spawn", .5f, 2);
    }

 void Spawn()
{
	Vector2 position = RandomPointRightFence(rightFence);
	GameObject rightWolf = Instantiate(wolf, position, Quaternion.identity);
    rightWolf.GetComponent<SpriteRenderer>().flipY = true;


    position = RandomPointLeftFence(leftFence);
    GameObject leftWolf = Instantiate(wolf, position, Quaternion.identity);
    leftWolf.GetComponent<SpriteRenderer>().flipX = false;
}


    Vector3 RandomPointRightFence ( GameObject fence ) {
	 Vector3 pos = new Vector3();

	 pos.x = fence.transform.position.x + 3f;
     float height = fence.GetComponent<BoxCollider2D>().size.y;
     pos.y = fence.transform.position.y + Random.Range(-height/2, height/2);

	 return pos;
}

    Vector3 RandomPointLeftFence ( GameObject fence ) {
	 Vector3 pos = new Vector3();

	 pos.x = fence.transform.position.x - 3f;
     float height = fence.GetComponent<BoxCollider2D>().size.y;
     pos.y = fence.transform.position.y + Random.Range(-height/2, height/2);

	 return pos;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 2f;

    Vector2 dir;

    public GameObject[] chickens;

    private bool isRunning = false;

    private GameObject checkenTobeFollowed;
    // Start is called before the first frame update
    void Start()
    {
        chickens = GameObject.FindGameObjectsWithTag("chicken");
        GetComponent<Animator>().SetBool("isAttacking",false);
        rb = GetComponent<Rigidbody2D>();
        if (chickens.Length>0)
        checkenTobeFollowed = chickens[Random.Range(0, chickens.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        if (checkenTobeFollowed) {
            dir = (checkenTobeFollowed.transform.position - transform.position).normalized;
            float dist = Vector3.Distance(checkenTobeFollowed.transform.position, transform.position);
            if (dist<4f) {
                if (!isRunning) {
                StartCoroutine("waitForAttack");
                if (chickens.Length>0)
                checkenTobeFollowed = chickens[Random.Range(0, chickens.Length)];
                }   
            }
        } else {
            if (chickens.Length>0)
            checkenTobeFollowed = chickens[Random.Range(0, chickens.Length)];
        }


        
    }

    void FixedUpdate()
{
		rb.velocity = dir * speed;

		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		rb.rotation = angle;
}

IEnumerator waitForAttack() {
    isRunning = true;
    GetComponent<Animator>().SetBool("isAttacking",true);

    yield return new WaitForSeconds( GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

    Destroy(checkenTobeFollowed);
    GetComponent<Animator>().SetBool("isAttacking",false);
    isRunning = false;
}
}

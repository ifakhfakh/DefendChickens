using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

     Vector2 movement;
    Vector2 mousePos;

    public float moveSpeed = 3f; 
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

 private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
    }
    void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        //     if (Input.GetMouseButton(0))
        // {
        //     Vector3 position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        //     GameObject clone = Instantiate(original, position ,Quaternion.identity);

        //     Destroy(clone, 1f);
        // }
    }
}

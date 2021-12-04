using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject Visual;
    public float moveSpeed = 5f;
    public Turtle turtle;
    public Hotbar hotbar;
    public GameObject[] prefabs;
    public Transform prefabContainer;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = Visual.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.magnitude > 0f) 
        {
            turtle.StartWalking();
            hotbar.Show();
        }
        if (movement.x > 0.1)
        {
            spriteRender.flipX = true;
        }
        else if (movement.x < -0.1)
        {
            spriteRender.flipX = false;
        }

        int objToPlace = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            objToPlace = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            objToPlace = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            objToPlace = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            objToPlace = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            objToPlace = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            objToPlace = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            objToPlace = 6;
        }

        if (objToPlace != -1) 
        {
            GameObject go = Instantiate(prefabs[objToPlace], prefabContainer);
            go.transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, 0f);
        }
    }

    void FixedUpdate()
    {
        // physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

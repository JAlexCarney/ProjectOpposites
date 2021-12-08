using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public Vector2 moveDirection = new Vector2(1f, 0f);
    public float baseSpeed = 2.5f;
    public float moveSpeedMultiplier = 2f;
    private float moveSpeed;
    public Transform cameraTransform;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isWalking = false;
    private bool isOver = false;

    public void StartWalking() {
        isWalking = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        moveSpeed = moveSpeedMultiplier;
    }

    void FixedUpdate()
    {
        if (isWalking && !isOver)
        {
            // physics
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
            cameraTransform.position = new Vector3(Mathf.Round(transform.position.x * 100f) / 100f, 0f, -10f);
        }
    }

    IEnumerator TriggerCollideOnDelay(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f / moveSpeed);

        if (collision.CompareTag("Hazard"))
        {
            GameOverScreen.SetActive(true);
            isOver = true;
            sr.flipY = true;
        }
        else if (collision.CompareTag("Up"))
        {
            moveDirection = new Vector2(0f, 1f);
            anim.SetInteger("WalkingDirection", 3);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Down"))
        {
            moveDirection = new Vector2(0f, -1f);
            anim.SetInteger("WalkingDirection", 2);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Right"))
        {
            moveDirection = new Vector2(1f, 0f);
            Destroy(collision.gameObject);
            anim.SetInteger("WalkingDirection", 0);
            sr.flipX = false;
        }
        else if (collision.CompareTag("Left"))
        {
            moveDirection = new Vector2(-1f, 0f);
            Destroy(collision.gameObject);
            anim.SetInteger("WalkingDirection", 1);
            sr.flipX = true;
        }
        else if (collision.CompareTag("Fast"))
        {
            moveSpeed *= moveSpeedMultiplier;
            anim.speed *= moveSpeedMultiplier;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Slow"))
        {
            moveSpeed /= moveSpeedMultiplier;
            anim.speed /= moveSpeedMultiplier;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Jump"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Goal")) 
        {
            isOver = true;
            WinScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("TriggerCollideOnDelay", collision);
    }
}

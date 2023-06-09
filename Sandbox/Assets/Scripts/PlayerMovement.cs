using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;
    private float playerSpeed;
    void Start()
    {
        playerSpeed = GetComponent<PlayerProperties>().speed;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", movement.x);
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", movement.y);
        //Debug.Log(movement);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
    }
}

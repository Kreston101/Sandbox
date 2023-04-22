using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;

    private Vector2 movement;
    void Start()
    {
        
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
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}

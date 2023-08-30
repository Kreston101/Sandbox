using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//generzlixed enemy script before i break eveything into class based and make everything do funny stuff
//dont enemies nomrally just do the same thing but do more damage over time?
//the game would get very boring wouldnt it?

public class Enemies : MonoBehaviour //for all intents and purposes, basic spider, but i m not undescided shit long ass names
{
    public float health;
    public float damage;

    private GameManager gm;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //look at player
        //move towards player
        //on the player side, start a coroutine
        //if player not out of hitbox by then, damage player

        //object queueing btw
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox"))
        {
            Debug.Log("entered trigger");
        }
    }

    private void ChasePlayer()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = playerPos - transform.position; //get vector of obj to playerpos
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector2 movementDir = Vector3.Normalize(playerPos - transform.position);
        rb.MovePosition(rb.position + movementDir * 2 * Time.deltaTime);
    }

    public void TakeDamage(float damageRecieved)
    {
        health -= damageRecieved;
    }
}
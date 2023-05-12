using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float health;

    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            gm.RemoveTarget(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox"))
        {
            //call gamemanager to put this obj into player targets list
            gm.AddToTargets(gameObject);
            Debug.Log("entered trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //remove this obj from the targets list
        if (collision.CompareTag("Hitbox"))
        {
            gm.RemoveTarget(gameObject);
            Debug.Log("exited trigger");
        }
    }

    public void TakeDamage(float damageRecieved)
    {
        health -= damageRecieved;
    }
}

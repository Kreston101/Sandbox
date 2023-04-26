using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox"))
        {
            //call gamemanager to put this obj into player targets list
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //remove this obj from the targets list
    }
}

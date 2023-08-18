using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public float bulletSpeed;
    public float angle;

    private Rigidbody2D rb;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation = angle;
        //rb.MovePosition(rb.transform.position + Vector3.up * bulletSpeed * Time.deltaTime);
    }
}

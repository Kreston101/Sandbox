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

        float xValue = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1;
        float yValue = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1;

        direction = new Vector3(xValue, yValue, 0);
        transform.eulerAngles = new Vector3(0, 0, angle * -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction.normalized * bulletSpeed * Time.deltaTime);
    }
}

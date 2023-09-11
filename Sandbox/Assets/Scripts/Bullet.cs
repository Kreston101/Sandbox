using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //pool this item
    public float bulletSpeed;
    public float lifeTime;
    public float damage;
    public float angle;

    void Start()
    {
        //transform.eulerAngles = new Vector3(0, 0, angle + 90);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

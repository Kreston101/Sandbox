using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public float speed;
    public float health;
    public float damage;
    public float fireRate;
    public GameObject weaponHand;
    public GameObject bullet;
    public GameObject[] bulletSpawnPoint;

    [SerializeField]
    private SpriteRenderer spriteFace;
    [SerializeField]
    private Sprite[] faces;
    private bool cooldown;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (cooldown == false)
            {
                StartCoroutine(WeaponDelay(fireRate));
                Fire();
            }
        }

        if(health <= 0)
        {
            spriteFace.sprite = faces[3];
        }
    }

    public void TakeDamage(float damageRecieved) //prep for name changes, inheritable
    {
        health -= damage;
        spriteFace.sprite = faces[1];
        StartCoroutine(Delay(1f));
    }

    public void Healed() //prep for name changes, inheritable
    {
        health += 1;
        spriteFace.sprite = faces[2];
        StartCoroutine(Delay(1f));
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteFace.sprite = faces[0];
    }

    private IEnumerator WeaponDelay(float delay)
    {
        cooldown = true;
        yield return new WaitForSeconds(delay);
        cooldown = false;
    }

    private void Fire()
    {
        Debug.Log("bang");
        GameObject bulletHolder;
        foreach(GameObject bulletSpawn in bulletSpawnPoint)
        {
            bulletHolder = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
            Debug.Log(bulletHolder.transform);
            Rigidbody2D rb2d = bulletHolder.GetComponent<Rigidbody2D>();
            rb2d.GetComponent<Bullet>().damage = damage;
            rb2d.velocity = bulletHolder.GetComponent<Bullet>().bulletSpeed * bulletSpawn.transform.up;
            bulletHolder.GetComponent<Bullet>().angle = weaponHand.transform.eulerAngles.z;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.GetComponent<Enemies>().damage);
        }
    }
}

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

    // Update is called once per frame
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

    public void TakeDamage(float damageRecieved) //prep for name changes
    {
        health -= damage;
        spriteFace.sprite = faces[1];
        StartCoroutine(Delay(1f));
    }

    public void Healed() //prep for name changes
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
        GameObject bulletHolder;
        foreach(GameObject bulletSpawn in bulletSpawnPoint)
        {
            bulletHolder = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
            Rigidbody2D rb2d = bulletHolder.GetComponent<Rigidbody2D>();
            rb2d.velocity = bulletHolder.GetComponent<Bullet>().bulletSpeed * bulletSpawn.transform.up;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public float speed;
    public float health;
    public float damage;
    public float fireRate;
    public List<GameObject> targets;

    [SerializeField]
    private SpriteRenderer spriteFace;
    [SerializeField]
    private Sprite[] faces;
    private bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cooldown == false)
            {
                StartCoroutine(WeaponDelay(1f));
                DamageEnemies();
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
        spriteFace.color = new Color(255,139,139);
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

    private void DamageEnemies()
    {
        Debug.Log("bang");
        foreach(GameObject enemy in targets)
        {
            //remember to do tag checking here
            //obstacles can and will be a thing
            enemy.GetComponent<Enemies>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            TakeDamage(collision.GetComponent<Enemies>().damage);
        }
    }
}

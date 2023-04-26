using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public float speed;
    public int health;
    public float damage;
    public float fireRate;
    public List<GameObject> targets;

    [SerializeField]
    private SpriteRenderer spriteFace;
    [SerializeField]
    private Sprite[] faces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakenDamage() //prep for name changes
    {
        health -= 1;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerProperties>().TakenDamage();
    }

    public void HealPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerProperties>().Healed();
    }
}

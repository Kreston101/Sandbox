using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugItems : MonoBehaviour
{
    GameObject[] enemies;
    GameObject enemieToSpawn;

    public void DamagePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerProperties>().TakeDamage(1f);
        Debug.Log("damaged player");
    }

    public void HealPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerProperties>().Healed();
        Debug.Log("healed player");
    }

    public void SpawnEnemy()
    {
        Instantiate(enemieToSpawn, Vector3.zero, Quaternion.identity);
        Debug.Log("spawned enemy");
    }
}

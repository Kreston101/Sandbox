using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugItems : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemieToSpawn;
    private GameManager gm;
    private GameObject player;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void DamagePlayer()
    {
        player.GetComponent<PlayerProperties>().TakeDamage(1f);
        Debug.Log("damaged player");
    }

    public void HealPlayer()
    {
        player.GetComponent<PlayerProperties>().Healed();
        Debug.Log("healed player");
    }

    public void SpawnEnemy()
    {
        Instantiate(enemieToSpawn, player.transform.position + Vector3.left * 5, Quaternion.identity);
        Debug.Log("spawned enemy");
    }

    public void ToggleSpawning()
    {
        gm.spawnToggle = !gm.spawnToggle;
    }
}

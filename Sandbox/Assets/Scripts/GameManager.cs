using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //omg, organisation :O
    [Header("Prefabs")]
    public GameObject player;
    public PlayerProperties playerProp;
    public GameObject[] enemies;

    [Header("Spawn settings")]
    public float spawnRange = 12f;
    public bool spawnToggle = true;
    private bool canSpawn = true;
    public float spawnDelay = 1f;

    [Header("Huds")]
    public GameObject huds;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerProp = player.GetComponent<PlayerProperties>();
        huds.GetComponent<Huds>().SetHealthBar(playerProp.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && spawnToggle)
        {
            SpawnEnemies();
        }

        //i think i should be using the player call this but...
        if(playerProp.currentHealth <= 0)
        {
            Time.timeScale = 0;
        }
        huds.GetComponent<Huds>().ChangeHealthBar(playerProp.currentHealth);
    }

    //it works i guess
    public void SpawnEnemies()
    {
        int randInt = Random.Range(1, 4);
        for(int i = 1; i <= randInt; i++)
        {
            int ranPoint = Random.Range(1, 9);
            switch (ranPoint)
            {
                case 1:
                    Instantiate(enemies[0], player.transform.position + new Vector3(12, 0, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemies[0], player.transform.position + new Vector3(0, 12, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemies[0], player.transform.position + new Vector3(-12, 0, 0), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemies[0], player.transform.position + new Vector3(0, -12, 0), Quaternion.identity);
                    break;
                case 5:
                    Instantiate(enemies[0], player.transform.position + new Vector3(12, 12, 0), Quaternion.identity);
                    break;
                case 6:
                    Instantiate(enemies[0], player.transform.position + new Vector3(-12, -12, 0), Quaternion.identity);
                    break;
                case 7:
                    Instantiate(enemies[0], player.transform.position + new Vector3(12, -12, 0), Quaternion.identity);
                    break;
                case 8:
                    Instantiate(enemies[0], player.transform.position + new Vector3(-12, 12, 0), Quaternion.identity);
                    break;
            }
        }
        StartCoroutine("SpawnDelay");
    }

    //multiple differen types of delays for different enemies?
    private IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }
}

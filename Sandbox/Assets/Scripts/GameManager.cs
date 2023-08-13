using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayerProperties playerProp;
    public GameObject[] enemies;
    public float spawnRange = 12f;
    public GameObject huds;

    public bool spawnToggle = true;

    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerProp = player.GetComponent<PlayerProperties>();
        huds.GetComponent<Huds>().SetHealthBar(playerProp.health);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && spawnToggle)
        {
            SpawnEnemies();
        }

        huds.GetComponent<Huds>().ChangeHealthBar(playerProp.health);
    }

    public void AddToTargets(GameObject enemyInRange)
    {
        if (playerProp.targets.Count <= 5)
        {
            playerProp.targets.Add(enemyInRange);
            Debug.Log("Target ADDED");
        }
    }

    public void RemoveTarget(GameObject enemyExited)
    {
        playerProp.targets.Remove(enemyExited);
        Debug.Log("target removed");
    }

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

    private IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(1f);
        canSpawn = true;
    }
}

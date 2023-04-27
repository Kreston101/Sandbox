using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayerProperties playerProp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerProp = player.GetComponent<PlayerProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}

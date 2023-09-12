using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour
{
    public GameObject[] playerToFollow;
    private GameObject followingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject player in playerToFollow)
        {
            if (player.activeInHierarchy)
            {
                followingPlayer = player;
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(followingPlayer.transform.position.x, followingPlayer.transform.position.y, transform.position.z);
    }
}

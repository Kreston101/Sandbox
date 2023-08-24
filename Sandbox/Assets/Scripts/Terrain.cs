using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public GameObject[] tiles;

    void Start()
    {
        for (int x = -2; x < 3; x++)
        {
            for (int y = -2; y < 3; y++)
            {
                int randTile = Random.Range(0, 5); //4 - large grass 3 2 - specced grass 0 1 - normal grass
                if(randTile >= 3) // >= 3
                {
                    GameObject tempTile = Instantiate(tiles[1],
                    new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0),
                    Quaternion.identity,
                    gameObject.transform);
                }
                else
                {
                    GameObject tempTile = Instantiate(tiles[0],
                    new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0),
                    Quaternion.identity,
                    gameObject.transform);
                }
            }
        }
    }
}

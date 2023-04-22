using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public GameObject tile;
    private Color terrainColor;
    // Start is called before the first frame update
    void Start()
    {
        //terrainColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);

        for (int x = -2; x < 3; x++)
        {
            for (int y = -2; y < 3; y++)
            {
                GameObject tempTile = Instantiate(tile, 
                    new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0), 
                    Quaternion.identity, 
                    gameObject.transform);
                //tempTile.GetComponent<SpriteRenderer>().color = terrainColor;
            }
        }
    }
}

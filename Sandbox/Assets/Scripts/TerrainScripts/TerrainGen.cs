using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public GameObject terrainFab;
    public List<GameObject> terrainList;

    float minX, minY, maxX, maxY;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = -20; x <= 20; x += 5)
        {
            for (int y = -20; y <= 20; y += 5)
            {
                GameObject temp = Instantiate(terrainFab, new Vector3(x, y, 0), Quaternion.identity);
                terrainList.Add(temp);
            }
        }
        minX = -9;
        maxX = 9;
        minY = -9;
        maxY = 9;
    }

    // Update is called once per frame
    void Update()
    {
        //left
        if (Camera.main.transform.position.x < minX)
        {
            for (int i = 0; i < 3; i++)
            {
                for (float y = minY; y <= maxY; y += 5)
                {
                    Debug.Log(minY);
                    Debug.Log(maxY);
                    Debug.Log(y);
                    GameObject temp = Instantiate(terrainFab, new Vector3(minX - 5, y, 0), Quaternion.identity);
                    terrainList.Add(temp);
                }
                minX -= 5;
                Debug.Log("exceeded left");
            }
        }
        //right
        if (Camera.main.transform.position.x > maxX)
        {
            for (int i = 0; i < 3; i++)
            {
                for (float y = minY; y <= maxY; y += 5)
                {
                    Debug.Log(minY);
                    Debug.Log(maxY);
                    Debug.Log(y);
                    GameObject temp = Instantiate(terrainFab, new Vector3(maxX + 5, y, 0), Quaternion.identity);
                    terrainList.Add(temp);
                }
                maxX += 5;
                Debug.Log("exceeded right");
            }
        }

        //down
        if (Camera.main.transform.position.y < minY)
        {
            for (int i = 0; i < 3; i++)
            {
                for (float x = minX; x <= maxX; x += 5)
                {
                    Debug.Log(minX);
                    Debug.Log(maxX);
                    Debug.Log(x);
                    GameObject temp = Instantiate(terrainFab, new Vector3(x, minY - 5, 0), Quaternion.identity);
                    terrainList.Add(temp);
                }
                minY -= 5;
                Debug.Log("exceeded down");
            }
        }
        //up
        if (Camera.main.transform.position.y > maxY)
        {
            for (int i = 0; i < 3; i++)
            {
                for (float x = minX; x <= maxX; x += 5)
                {
                    Debug.Log(minX);
                    Debug.Log(maxX);
                    Debug.Log(x);
                    GameObject temp = Instantiate(terrainFab, new Vector3(x, maxY + 5, 0), Quaternion.identity);
                    terrainList.Add(temp);
                }
                maxY += 5;
                Debug.Log("exceeded up");
            }
            
        }
    }
}

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
        for(int x = -9; x <= 9; x += 3)
        {
            for (int y = -9; y <= 9; y += 3)
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
        if(Camera.main.transform.position.x < minX)
        {
            for(float y = minY; y <= maxY; y += 3)
            {
                Debug.Log(minY);
                Debug.Log(maxY);
                Debug.Log(y);
                GameObject temp = Instantiate(terrainFab, new Vector3(minX - 3, y, 0), Quaternion.identity);
                terrainList.Add(temp);
            }
            minX -= 3;
            Debug.Log("exceeded left");
        }
        //right
        if (Camera.main.transform.position.x > maxX)
        {
            for (float y = minY; y <= maxY; y += 3)
            {
                Debug.Log(minY);
                Debug.Log(maxY);
                Debug.Log(y);
                GameObject temp = Instantiate(terrainFab, new Vector3(maxX + 3, y, 0), Quaternion.identity);
                terrainList.Add(temp);
            }
            maxX += 3;
            Debug.Log("exceeded right");
        }

        //down
        if (Camera.main.transform.position.y < minY)
        {
            for (float x = minX; x <= maxX; x += 3)
            {
                Debug.Log(minX);
                Debug.Log(maxX);
                Debug.Log(x);
                GameObject temp = Instantiate(terrainFab, new Vector3(x, minY - 3, 0), Quaternion.identity);
                terrainList.Add(temp);
            }
            minY -= 3;
            Debug.Log("exceeded down");
        }
        //up
        if (Camera.main.transform.position.y > maxY)
        {
            for (float x = minX; x <= maxX; x += 3)
            {
                Debug.Log(minX);
                Debug.Log(maxX);
                Debug.Log(x);
                GameObject temp = Instantiate(terrainFab, new Vector3(x, maxY + 3, 0), Quaternion.identity);
                terrainList.Add(temp);
            }
            maxY += 3;
            Debug.Log("exceeded up");
        }
    }
}

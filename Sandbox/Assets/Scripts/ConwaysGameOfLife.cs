using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwaysGameOfLife : MonoBehaviour
{
    //Reminder to try that new indexing method (wait that might be very messy-)
    public GameObject tile;
    public int xLength;
    public int yLength;

    public List<GameObject> allTiles;
    [SerializeField]
    public List<List<GameObject>> rowLists = new List<List<GameObject>>();

    public bool start = false;
    public bool stepTaken = false;

    void Start()
    {
        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                allTiles.Add(Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity, transform));
            }
        }
        transform.position = new Vector3(-20, -9, 0);
        int tileIndex = 0;
        for (int i = 0; i < 19; i++)
        {
            List<GameObject> yRow = new List<GameObject>();
            for(int xTiles = tileIndex; xTiles < tileIndex + 41; xTiles++)
            {
                yRow.Add(allTiles[xTiles]);
                //Debug.Log($"added{allTiles[xTiles]}");
            }
            rowLists.Add(yRow);
            tileIndex += 41;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
            StartCoroutine(Step());
        }

        if (start == true)
        {
            if(stepTaken == true)
            {
                //Debug.Log(tileLists.Count);
                for (int rowNum = 0; rowNum < rowLists.Count; rowNum++)
                {
                    for (int tileIndex = 0; tileIndex < rowLists[rowNum].Count; tileIndex++)
                    {
                        GameObject tile = rowLists[rowNum][tileIndex];
                        int liveNeighbours = FindTileNeighbours(rowNum, tileIndex);
                        switch (liveNeighbours)
                        {
                            case 0:
                                tile.GetComponent<ConwayTile>().SetState(false);
                                break;
                            case 1:
                                tile.GetComponent<ConwayTile>().SetState(false);
                                break;
                            case 2:
                                break;
                            case 3:
                                tile.GetComponent<ConwayTile>().SetState(true);
                                break;
                            case 4:
                                tile.GetComponent<ConwayTile>().SetState(false);
                                break;
                        }
                    }
                }
            } 
        }
    }

    public int FindTileNeighbours(int rowIndex, int tileIndex)
    {
        int liveNeighbours = 0;
        //right and left
        if (tileIndex + 1 < rowLists[rowIndex].Count)
        {
            if (rowLists[rowIndex][tileIndex + 1].GetComponent<ConwayTile>().cellAlive == true)
            {
                liveNeighbours++;
            }
        }
        if (tileIndex - 1 >= 0)
        {
            if (rowLists[rowIndex][tileIndex - 1].GetComponent<ConwayTile>().cellAlive == true)
            {
                liveNeighbours++;
            }
        }
        //above and below
        if (rowIndex + 1 < rowLists.Count)
        {
            if (rowLists[rowIndex + 1][tileIndex].GetComponent<ConwayTile>().cellAlive == true)
            {
                liveNeighbours++;
            }
        }
        if (rowIndex - 1 >= 0)
        {
            if (rowLists[rowIndex - 1][tileIndex].GetComponent<ConwayTile>().cellAlive == true)
            {
                liveNeighbours++;
            }
        }
        return liveNeighbours;
    }

    public IEnumerator Step()
    {
        stepTaken = false;

        yield return new WaitUntil(() => stepTaken == true);
    }
}


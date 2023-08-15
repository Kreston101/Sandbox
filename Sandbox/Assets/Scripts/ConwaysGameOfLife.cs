using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwaysGameOfLife : MonoBehaviour
{
    public GameObject tile;
    public int xLength;
    public int yLength;

    public List<GameObject> allTiles;
    [SerializeField]
    public List<List<GameObject>> rowLists = new List<List<GameObject>>();

    public bool start = false;
    public bool tilesReady = false;

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
        for (int i = 0; i < yLength; i++)
        {
            List<GameObject> yRow = new List<GameObject>();
            for (int xTiles = tileIndex; xTiles < tileIndex + xLength; xTiles++)
            {
                yRow.Add(allTiles[xTiles]);
            }
            rowLists.Add(yRow);
            tileIndex += xLength;
        }

        for (int rowNum = 0; rowNum < rowLists.Count; rowNum++)
        {
            for (int tileNum = 0; tileNum < rowLists[rowNum].Count; tileNum++)
            {
                FindTileNeighbours(rowNum, tileNum);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
            Debug.Log("started tiles");
        }

        if (start == true)
        {
            StartCoroutine(Step());
            if (tilesReady == true)
            {
                foreach (GameObject tile in allTiles)
                {
                    tile.GetComponent<ConwayTile>().SetState();
                }
            }
        }
    }

    private IEnumerator Step()
    {
        Debug.Log("begin switch");
        tilesReady = false;
        foreach (GameObject tile in allTiles)
        {
            tile.GetComponent<ConwayTile>().CheckNeighbours();
            Debug.Log(tile.GetComponent<ConwayTile>().readyToChange);
        }
        tilesReady = true;
        yield return new WaitUntil(() => tilesReady == true);
        Debug.Log("end switch");
    }

    public void FindTileNeighbours(int rowIndex, int tileIndex)
    {
        List<GameObject> neighbourList = rowLists[rowIndex][tileIndex].GetComponent<ConwayTile>().neighbours;
        //right and left
        if (tileIndex + 1 < rowLists[rowIndex].Count)
        {
            neighbourList.Add(rowLists[rowIndex][tileIndex + 1]);
        }
        if (tileIndex - 1 >= 0)
        {
            neighbourList.Add(rowLists[rowIndex][tileIndex - 1]);
        }
        //above
        if (rowIndex + 1 < rowLists.Count)
        {
            neighbourList.Add(rowLists[rowIndex + 1][tileIndex]);

            if (tileIndex + 1 < rowLists[rowIndex].Count)
            {
                neighbourList.Add(rowLists[rowIndex + 1][tileIndex + 1]);
            }
            if (tileIndex - 1 >= 0)
            {
                neighbourList.Add(rowLists[rowIndex + 1][tileIndex - 1]);
            }
        }
        //below
        if (rowIndex - 1 >= 0)
        {
            neighbourList.Add(rowLists[rowIndex - 1][tileIndex]);

            if (tileIndex + 1 < rowLists[rowIndex].Count)
            {
                neighbourList.Add(rowLists[rowIndex - 1][tileIndex + 1]);
            }
            if (tileIndex - 1 >= 0)
            {
                neighbourList.Add(rowLists[rowIndex - 1][tileIndex - 1]);
            }
        }
    }
}

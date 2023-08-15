using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwayTile : MonoBehaviour
{
    public bool cellAlive = false;
    public GameObject anchor;
    public List<GameObject> neighbours;

    public bool readyToChange = false;
    public bool nextState = false;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    start = true;
        //    Debug.Log("started tiles");
        //}

        //if(start == true)
        //{
        //    Debug.Log("running tiles");
        //}
    }

    public void SetState()
    {
        cellAlive = nextState;
        if (cellAlive == true)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.black;
        }
        readyToChange = false;
    }

    private void OnMouseDown()
    {
        if (cellAlive == true)
        {
            cellAlive = false;
            sr.color = Color.black;
        }
        else
        {
            cellAlive = true;
            sr.color = Color.green;
        }
    }

    public bool CheckNeighbours()
    {
        int liveNeighbours = 0;
        foreach(GameObject tile in neighbours)
        {
            if(tile.GetComponent<ConwayTile>().cellAlive == true)
            {
                liveNeighbours++;
            }
        }
        switch (liveNeighbours)
        {
            case 0:
                nextState = false;
                break;
            case 1:
                nextState = false;
                break;
            case 2:
                if(cellAlive == true)
                {
                    nextState = true;
                }
                else
                {
                    nextState = false;
                }
                break;
            case 3:
                nextState = true;
                break;
            case 4:
                nextState = false;
                break;
            case 5:
                nextState = false;
                break;
            case 6:
                nextState = false;
                break;
            case 7:
                nextState = false;
                break;
            case 8:
                nextState = false;
                break;
        }
        return readyToChange = true;
    }
}

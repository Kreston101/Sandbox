using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwayTile : MonoBehaviour
{
    public bool cellAlive = false;
    public GameObject anchor;
    public List<GameObject> neighbours;

    public bool started = false;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            Debug.Log("started");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(started == true)
        {
            CheckNeighbours();
        }
    }

    public void SetState(bool isAlive)
    {
        cellAlive = isAlive;
        if (cellAlive == true)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.black;
        }
    }

    private void OnMouseDown()
    {
        if (cellAlive == true)
        {
            SetState(false);
        }
        else
        {
            SetState(true);
        }
    }

    private void CheckNeighbours()
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
                SetState(false);
                break;
            case 1:
                SetState(false);
                break;
            case 2:
                break;
            case 3:
                SetState(true);
                break;
            case 4:
                SetState(false);
                break;
            case 5:
                SetState(false);
                break;
            case 6:
                SetState(false);
                break;
            case 7:
                SetState(false);
                break;
            case 8:
                SetState(false);
                break;
        }
    }
}

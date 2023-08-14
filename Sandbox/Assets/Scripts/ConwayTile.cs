using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwayTile : MonoBehaviour
{
    public bool cellAlive = false;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(bool isAlive)
    {
        if (isAlive)
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
        Debug.Log("mouse");
        SetState(!cellAlive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpriteFlipper : MonoBehaviour
{
    public GameObject pointer;
    public GameObject charToFlip;
    public GameObject handToFlip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer.transform.eulerAngles.z < 90)
        {
            charToFlip.transform.localScale = new Vector3(1, charToFlip.transform.localScale.y, transform.localScale.z);
            handToFlip.transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
        else if (pointer.transform.eulerAngles.z < 180)
        {
            charToFlip.transform.localScale = new Vector3(-1, charToFlip.transform.localScale.y, transform.localScale.z);
            handToFlip.transform.localScale = new Vector3(transform.localScale.x, -1, transform.localScale.z);
        }
        else if (pointer.transform.eulerAngles.z < 270)
        {
            charToFlip.transform.localScale = new Vector3(-1, charToFlip.transform.localScale.y, transform.localScale.z);
            handToFlip.transform.localScale = new Vector3(transform.localScale.x, -1, transform.localScale.z);
        }
        else if (pointer.transform.eulerAngles.z < 360)
        {
            charToFlip.transform.localScale = new Vector3(1, charToFlip.transform.localScale.y, transform.localScale.z);
            handToFlip.transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
    }
}

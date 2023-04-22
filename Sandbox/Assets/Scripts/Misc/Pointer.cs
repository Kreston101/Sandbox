using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //converts mouse pos into world pos
        Vector3 direction = mousePos - transform.position; //get vector of obj to mousepos
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

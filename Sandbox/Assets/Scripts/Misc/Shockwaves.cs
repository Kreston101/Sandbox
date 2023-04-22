using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwaves : MonoBehaviour
{
    public GameObject projection;
    public List<GameObject> affected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(GameObject affectedObj in affected)
            {
                affectedObj.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(2,0) * 5, ForceMode2D.Impulse);
            }
        }
    }
}

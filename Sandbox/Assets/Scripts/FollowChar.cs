using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour
{
    public GameObject charToFollow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(charToFollow.transform.position.x, charToFollow.transform.position.y, transform.position.z);
    }
}

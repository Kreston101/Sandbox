using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellPattern : MonoBehaviour
{
    public GameObject pellet;
    public int bulletCount;
    public float delay;

    private bool delayRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPatternCircle();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!delayRunning)
        //{
        //    SpawnPatternCircle();
        //    StartCoroutine(PatternDelay());
        //}
    }

    private IEnumerator PatternDelay()
    {
        delayRunning = true;
        Debug.Log("delay started");
        yield return new WaitForSeconds(delay);
        delayRunning = false;
        Debug.Log("delay ended");
    }

    public void SpawnPatternCircle()
    {
        GameObject pelletHolder;
        float angle = 360 / bulletCount;
        for(int i = 0; i < bulletCount; i++)
        {
            pelletHolder = Instantiate(pellet, gameObject.transform.position, Quaternion.identity);
            pelletHolder.GetComponent<Pellet>().angle = angle*i;
        }
    }
}

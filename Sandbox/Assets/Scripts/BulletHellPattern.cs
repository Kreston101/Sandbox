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

    }

    // Update is called once per frame
    void Update()
    {
        if (!delayRunning)
        {
            SpawnPatternCircle();
            StartCoroutine(PatternDelay());
        }
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
            pelletHolder.GetComponent<Pellet>().angle = angle * i;
            //float xValue = pellet.transform.position.x + Mathf.Sin((angle * i * Mathf.PI) / 180) * 1;
            //float yValue = pellet.transform.position.x + Mathf.Cos((angle * i * Mathf.PI) / 180) * 1;

            //Vector3 direction = new Vector3(xValue, yValue, 0);
            //Debug.Log(direction.normalized);
            //Debug.Log(pelletHolder.transform.position);
            //.Log(pelletHolder.transform.position + direction.normalized);
            //pelletHolder.GetComponent<Rigidbody2D>().MovePosition(pelletHolder.transform.position + direction.normalized * bulletSpeed);
        }
    }
}

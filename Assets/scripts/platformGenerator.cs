using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{

    public GameObject platform;
    public GameObject spawnPlatform;
    //spawntime of platform
    public float spawnTime;
    //yUp max y on y axe for random spawn, yDown for min on y axe (maybe 3, 0 for test).
    private float yMin;
    private float yMax;
    private float actualPosition;
    // Start is called before the first frame update
    void Start()
    {
        yMin = -4.5f;
        yMax = 4.5f;
        Vector3 spawnPos = new Vector3(-2.5f, 0, 0);
        Instantiate(spawnPlatform, spawnPos, transform.rotation);
        actualPosition = -3;
        //call funktion that spawns your platform every spawnTime;
        InvokeRepeating("platformSpawn", 0, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void platformSpawn()
    {
        //random point on y axe for spawn
        float y = nextPlatform();
        actualPosition = y;
        //make vector3 for spawn position (i set z to zero)
        Vector3 pos = new Vector3(transform.position.x, y, 0);
        //set platform in the world (transform.rotation as from main gameObject ("platformController")
        Instantiate(platform, pos, transform.rotation);
    }
    float nextPlatform() {
        float max = actualPosition + 2;
        if (max > yMax) {
            max = actualPosition;
            }
        float y = Random.Range(yMin, max);
        return y;
        }

}

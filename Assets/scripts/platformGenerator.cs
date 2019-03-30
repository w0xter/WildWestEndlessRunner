using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{
	private float maxY;
	private float minY;
	public GameObject platform;
	public GameObject spawnPlatform;
	private float actualPosition;
	public float spwanTime;
    // Start is called before the first frame update
    void Start()
    {
        maxY = 4.5f;
        minY = -4.5f;
        createSpanwPlatform();
        InvokeRepeating("platformCreator", 0, spwanTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void platformCreator(){
    	float y  = generarSiguientePlataforma();
    	Vector3 xyzPosition = new Vector3(transform.position.x, y, 0);
    	Instantiate(platform, xyzPosition, platform.transform.rotation);
    }
    private	float generarSiguientePlataforma(){
    	float maxRango = actualPosition + 2;
    	if(maxRango > maxY)
    		maxRango = actualPosition;
    	float y  = Random.Range(minY, maxRango);
    	return y;
    }
    private void createSpanwPlatform(){
		Vector3 position = new Vector3(-3, -4, 0);
		Instantiate(spawnPlatform, position, spawnPlatform.transform.rotation);
		actualPosition = -4;



    }
}

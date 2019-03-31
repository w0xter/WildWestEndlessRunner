using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{
	private float maxY;
	private float minY;
	private GameObject platform;
	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;
	public GameObject platform5;
	public GameObject platform6;
	public GameObject platform7;
	public GameObject platform8;
	public GameObject platform9;
	private GameObject[] platforms;

	public GameObject spawnPlatform;
	private float actualPosition;
	public float spwanTime;
    // Start is called before the first frame update
    void Start()
    {
    	platforms = new GameObject[]{platform1, platform2, platform3, platform4, platform5, platform6, platform7, platform8, platform9};
        maxY = 4.5f;
        minY = -4.5f;
        createSpanwPlatform();
        if(playerController.isAlive){
     	   InvokeRepeating("platformCreator", 0, spwanTime);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void platformCreator(){
    	float y  = generarSiguientePlataforma();
    	Vector3 xyzPosition = new Vector3(transform.position.x, y, 0);
    	platform = platforms[(int) Random.Range(1, 9)];
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
		Vector3 position = new Vector3(-3, -5, 0);
		Instantiate(spawnPlatform, position, spawnPlatform.transform.rotation);
		actualPosition = -4;



    }
}

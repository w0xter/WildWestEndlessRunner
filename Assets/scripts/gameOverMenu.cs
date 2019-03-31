using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuCanvas;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenuCanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
        if(!playerController.isAlive){
            Time.timeScale = 0f;
            gameOverMenuCanvas.SetActive(true);
            
        }
       // Debug.Log("isAlive = " + playerController.isAlive);
        //Debug.Log("Time Scale = " + Time.timeScale);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("METEDELJUEGOAQUI");
    }

    

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuCanvas;
    public GameObject player;
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        gameOverMenuCanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        alive = player.transform.position.y >= -5F;
        if(!alive){
            gameOverMenuCanvas.SetActive(true);
            //Time.timeScale = 0f;
        }
        
        Time.timeScale = 0f;
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
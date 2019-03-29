using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public string mainMenu;

    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        
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
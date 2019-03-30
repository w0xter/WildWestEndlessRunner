using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public string mainMenu;

    public GameObject gameOverMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
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
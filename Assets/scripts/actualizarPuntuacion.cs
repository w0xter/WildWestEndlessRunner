using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarPuntuacion : MonoBehaviour {

    public int score;
    public Text scoreDisplay;

    private void Update()
    {
        score += (int) Time.deltaTime;
        scoreDisplay.text = score.ToString("Score: " + score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarPuntuacion : MonoBehaviour {

    public float score;
    public Text scoreDisplay;

    private void Update()
    {
        score += Time.deltaTime;
        scoreDisplay.text = "Score: " + score.ToString("0");
    }
}

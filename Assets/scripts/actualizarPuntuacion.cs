using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarPuntuacion : MonoBehaviour {

    public int score;
    public Text scoreDisplay;
    public bool plataformaPuntuada;
    public bool scoreUpdated;

    private void start(){
    	plataformaPuntuada = false;
    	scoreUpdated = false;
    }

    private void Update()
    {
    	
        if(playerController.isGrounded && !plataformaPuntuada){
        		score++;
        		plataformaPuntuada  = true;
        }
        if(!playerController.isGrounded){
        	plataformaPuntuada = false;
        }
        if(!playerController.isAlive && !scoreUpdated){
        	Debug.Log("SE HA MUERTOOOOOOOOOOOOOOOOOOOOOOOOOO");
        	scoreUpdated = true;
        	PlayerPrefs.SetInt("LastScore", score);
        	Debug.Log("PlayerPrefs " + PlayerPrefs.GetInt("LastScore"));
        }
        scoreDisplay.text = "" + score;
    }
}

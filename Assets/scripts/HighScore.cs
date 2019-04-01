using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    private const string scoreBoardFile = "./Assets/scripts/s.bin";
    private const int MAX  = 10;

    private int numberofScores;

	public List<int> scoreBoard;
    public int[] puntos;
    public int actualScore;
    public bool guardado;
    public bool alive;
    public GameObject scoreBoardCanvas;
    public RectTransform[] panel;
    public Text[] points;
    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponentsInChildren<RectTransform>();
        points = GetComponentsInChildren<Text>();
        scoreBoard = new List<int>();
        guardado  = false;
        numberofScores = 0;
        puntos  = loadPoints();
        scoreBoardCanvas.SetActive(false);
        
    }

    void Update(){
        alive = playerController.isAlive;
        if(!alive && !guardado && actualizarPuntuacion.sePuedeActualizar){
            Debug.Log("PlayerPrefs LastScore: " +  PlayerPrefs.GetInt("LastScore"));
            actualScore =  PlayerPrefs.GetInt("LastScore");
            Debug.Log("Actual Score: " + actualScore);
            if(updatedScore()){
                Debug.Log("ScoreActualizado:D");
                writeFile();
            }
            loadScoreBoard();
            guardado = true;
        }
    }
    private int[] loadPoints(){
        int i = 0;
        int[] puntos_aux = readFile(out i);
        while(i < MAX){
            puntos_aux[i] = 0;
            i++;
        }
        return puntos_aux;
    }

    private int[] readFile(out int i){
    	FileStream fs = new FileStream(scoreBoardFile, FileMode.OpenOrCreate);
    	BinaryReader br = new BinaryReader(fs);
        int[] puntos_aux = new int[MAX];
        i = 0;
    	while(br.BaseStream.Position != br.BaseStream.Length){
    		puntos_aux[i] = br.ReadInt32();
            i++;
            numberofScores++;
    	}
        br.Close();
    	fs.Close();
        return puntos_aux;
    }
    private  void writeFile(){
        FileStream fs = new FileStream(scoreBoardFile, FileMode.Open);
        BinaryWriter bw = new BinaryWriter(fs);
        foreach(int score in puntos){
            bw.Write(score);
        }
        bw.Close();
        fs.Close();
    }

    private void loadScoreBoard(){
         int i = 0;

        foreach (RectTransform R in panel)
        {
            points = R.GetComponentsInChildren<Text>();

            foreach (Text t in points)
            {
                if (i < 10)
                {
                    t.text = "" + puntos[i];
                    i++;
                }
            }
        }

    }
    private bool updatedScore(){
        bool updated = true;
        if(numberofScores + 1 < MAX){
            puntos[numberofScores + 1] = actualScore;
            Array.Sort(puntos);
            Array.Reverse(puntos);
        }else{
            Array.Sort(puntos);
            Array.Reverse(puntos);
            if(puntos[MAX - 1] < actualScore){
                puntos[MAX - 1 ] = actualScore;
            }else{
                updated = false;
            }
            Array.Sort(puntos);
            Array.Reverse(puntos);
        }
        return updated;
    }

}


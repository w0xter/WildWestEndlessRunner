using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScore : MonoBehaviour
{
	public List<int> scoreBoard;
	public string scoreBoardFile;
    public int actualScore;
    public bool guardado;
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = new List<int>();
        guardado  = false;
        scoreBoardFile = "scoreBoard.dat";
        readFile();        
    }

    void Update(){
        alive = playerController.isAlive;
        if(!alive && !guardado){
            Debug.Log("AQUI NUNCA ENTRO LOL");
            Debug.Log("PlayerPrefs LastScore: " +  PlayerPrefs.GetInt("LastScore"));
            actualScore =  PlayerPrefs.GetInt("LastScore");
            Debug.Log("Actual Score: " + actualScore);
            scoreBoard.Add(actualScore);
            scoreBoard.Sort((a,b)=> -1*a.CompareTo(b));
            writeFile();
            guardado = true;
        }
    }

    private void readFile(){
    	FileStream fs = new FileStream(scoreBoardFile, FileMode.Open);
    	BinaryReader br = new BinaryReader(fs);
    	var scoreValue = br.ReadInt32();
    	while(br.BaseStream.Position != br.BaseStream.Length){
    		scoreValue = br.ReadInt32();
    		scoreBoard.Add(scoreValue);
    	}
        br.Close();
    	
    }
    private void writeFile(){
        if(scoreBoard.Count > 5){
            scoreBoard.RemoveAt(scoreBoard.Count - 1);
        }
        BinaryWriter bw = new BinaryWriter(new FileStream(scoreBoardFile, FileMode.Open));
        foreach(int score in scoreBoard){
            bw.Write(score);
        }
        bw.Close();
    }
}


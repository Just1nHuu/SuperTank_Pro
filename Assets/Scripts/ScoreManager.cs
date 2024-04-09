using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text player1ScoreText;

    public Text player2ScoreText;

    private int player1Score = 0;

    private int player2Score = 0;

	// Use this for initialization
	void Start () {
        player1ScoreText.text = "0";
        player2ScoreText.text = "0";
	}

    public void OnPlayerDamaged(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player2Score++;
        }
        else if (playerNumber == 2)
        {
            player1Score++;
        }

        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

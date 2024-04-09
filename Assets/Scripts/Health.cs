using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int playerNumber = 1;

    public int startHealth = 5;

    private int currentHealth;

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        currentHealth = startHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
	}

    public void TakeDamage()
    {
        currentHealth--;
        scoreManager.OnPlayerDamaged(playerNumber);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

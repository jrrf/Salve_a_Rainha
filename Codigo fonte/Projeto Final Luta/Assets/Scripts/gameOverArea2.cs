using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverArea2 : MonoBehaviour {

    public int vida1;
    public float tempoCorrente;
    public float tempoFimJogo;
    public bool tempoIniciado;

	void Start () {
	}
	
	void Update () {
        vida1 = playerControlle1.vida;

        if (vida1 < 1 && !tempoIniciado){
            tempoCorrente = 0;
            tempoIniciado = true;
        }

        if (tempoIniciado){
            tempoCorrente += Time.deltaTime;
            if (tempoCorrente > tempoFimJogo)
            {
                SceneManager.LoadScene("GameOverArea2");
            }
        }
        
	}
}

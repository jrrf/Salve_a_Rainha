using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverArea1 : MonoBehaviour {

    public int vida1;
    public float tempoCorrente;
    public float tempoFimJogo;
    public bool tempoIniciado = false;
    private float tempo;

    void Start () {

	}
	
	void Update () {
        vida1 = playerControlle1.vida;
        tempo += Time.deltaTime;

        if (vida1 < 1 && !tempoIniciado)
        {
            tempoCorrente = 0;
            tempoIniciado = true;
        }
        
        if(tempo>3 && playerControlle1.posicaoY < -5f)
        {
            SceneManager.LoadScene("GameOverArea1");
        }

        if (tempoIniciado)
        {
            tempoCorrente += Time.deltaTime;
            if (tempoCorrente > tempoFimJogo)
            {
                PlayerPrefs.SetInt("vida", 100);
                SceneManager.LoadScene("GameOverArea1");
            }
        }

    }
}

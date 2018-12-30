using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winArea2 : MonoBehaviour {
    public int vida2;
    public float tempoCorrente;
    public float tempoFimJogo;
    public bool tempoIniciado;

    void Start()
    {
    }

    void Update()
    {
        vida2 = playerControlle2.vida;
        if (vida2 < 10 && !tempoIniciado)
        {
            tempoCorrente = 0;
            tempoIniciado = true;
        }

        if (tempoIniciado)
        {
            tempoCorrente += Time.deltaTime;
            if (tempoCorrente > tempoFimJogo)
            {
                SceneManager.LoadScene("winArea2");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaControlle : MonoBehaviour {

    public float velocidade;
    public float TempoMovimento;
    private bool sentidoEsquerda;
    private float tempoCorrente = 0f;


	void Start () {
		
	}
	

	void Update () {
        tempoCorrente += Time.deltaTime;

        if (tempoCorrente <= TempoMovimento)
        {
            if (sentidoEsquerda)
                transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
            else transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        else
        {
            sentidoEsquerda = !sentidoEsquerda;
            tempoCorrente = 0f;
        }
	}
}

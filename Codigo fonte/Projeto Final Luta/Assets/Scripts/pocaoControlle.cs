using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocaoControlle : MonoBehaviour {

    public float velocidade;
    public float TempoMovimento;
    private bool sentidoEsquerda;
    private float tempoCorrente = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempoCorrente += Time.deltaTime;

        if (tempoCorrente <= TempoMovimento)
        {
            if (sentidoEsquerda)
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
            else transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }
        else
        {
            sentidoEsquerda = !sentidoEsquerda;
            tempoCorrente = 0f;
        }
    }
}

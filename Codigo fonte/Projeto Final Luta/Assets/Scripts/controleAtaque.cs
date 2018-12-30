using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleAtaque : MonoBehaviour {
    
    private float tempoCorrente;
    public float tempoAtaque;

    void Start () {
        tempoCorrente = 0;

	}
	

	void Update () {
        tempoCorrente += Time.deltaTime;
        if(tempoCorrente>tempoAtaque)
            Destroy(transform.gameObject);
	}
}

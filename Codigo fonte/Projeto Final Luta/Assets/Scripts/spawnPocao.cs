using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPocao : MonoBehaviour {
    public GameObject pocaoVida, pocaoAtaque;
    private bool novoTempo;
    private float tempoCorrente;
    private float intervaloTempo;

	// Use this for initialization
	void Start () {
        novoTempo = true;
        tempoCorrente = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        tempoCorrente += Time.deltaTime;

        if (novoTempo)
        {
            intervaloTempo = Random.Range(5, 15);
            novoTempo = !novoTempo;
        }

        if (intervaloTempo < tempoCorrente)
        {
            
            if (Random.Range(1, 3) == 1)
            {
                GameObject prefab = Instantiate(pocaoAtaque) as GameObject;
                prefab.transform.position = transform.position;
            }
            else {
                GameObject prefab = Instantiate(pocaoVida) as GameObject;
                prefab.transform.position = transform.position;
            }
            tempoCorrente = 0;
        }


    }
}

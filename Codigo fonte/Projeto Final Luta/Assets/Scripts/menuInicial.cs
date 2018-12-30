using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour {

    public AudioSource audio;
    public AudioClip somBotao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void sairDoJogo()
    {
        Application.Quit();
    }

    public void iniciarJogo()
    {
        PlayerPrefs.SetInt("vida", 100);
        SceneManager.LoadScene("Area1");
    }

    public void menuPrincipal()
    {
        SceneManager.LoadScene("menuInicial");
    }
    public void somDoBotao()
    {
        audio.PlayOneShot(somBotao);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicioPartidaArea2 : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("return") || Input.GetKeyDown("enter") || Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Area2");
        }
    }
}

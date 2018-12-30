using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winArea1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 100.6f)
        {
            PlayerPrefs.SetInt("vida", playerControlle1.vida);
            SceneManager.LoadScene("winArea1");
        }
	}
}

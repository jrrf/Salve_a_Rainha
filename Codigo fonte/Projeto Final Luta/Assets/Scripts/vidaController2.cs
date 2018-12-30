using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaController2 : MonoBehaviour {
    public Texture Sangue2, Contorno2,umAtaque, doisAtaque, tresAtaque;
    public int VidaCheia;
    public float x, y, a, c, x1, x2, x3, y1, a1, c1, c2;
    public int vida;
    void Start()
    {
        x = 1.6f;
        y = 32.75f;
        a = 28.6f;
        c = 3.38f;
        VidaCheia = 100;
        x1 = 1.102f;
        x2 = 1.119f;
        x3 = 1.139f;
        y1 = 13.5f;
        c1 = 69f;
        c2 = 59.3f;
        a1 = 66f;

    }
    void Update()
    {
        vida = playerControlle1.vida;
    }
    void OnGUI()
    {   //                               x ,                y,                 comprimento,               altura     
        GUI.DrawTexture(new Rect(Screen.width / 1.675f, Screen.height / 90, Screen.width / 2.5f, Screen.height / 9.5f), Contorno2);
        GUI.DrawTexture(new Rect(Screen.width / x, Screen.height / y, Screen.width / c / VidaCheia * playerControlle2.vida, Screen.height / a), Sangue2);

        if (playerControlle2.temAtaque >= 1)
            GUI.DrawTexture(new Rect(Screen.width / x1, Screen.height / y1, Screen.width / c1, Screen.height / a1), umAtaque);
        if (playerControlle2.temAtaque >= 2)
            GUI.DrawTexture(new Rect(Screen.width / x2, Screen.height / y1, Screen.width / c2, Screen.height / a1), doisAtaque);
        if (playerControlle2.temAtaque >= 3)
            GUI.DrawTexture(new Rect(Screen.width / x3, Screen.height / y1, Screen.width / c2, Screen.height / a1), tresAtaque);
        
    }
}
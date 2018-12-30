using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaController1 : MonoBehaviour {

    public Texture Sangue1, Contorno1, umAtaque, doisAtaque, tresAtaque;
    public int VidaCheia;
    public float x, y, a, c, x1, x2, x3, y1,a1,c1, c2;
    public int vida;
    void Start()
    {
        x = 12.51f;
        y = 32.75f;
        a = 28.6f;
        c = 3.38f;
        VidaCheia = 100;
        x1 = 12.8f;
        x2 = 11.1f;
        x3 = 9.5f;
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
    {   //                              x ,                 y,               comprimento,          altura     
        GUI.DrawTexture(new Rect(Screen.width / 90, Screen.height / 90, Screen.width / 2.5f, Screen.height / 9.5f), Contorno1);
        GUI.DrawTexture(new Rect(Screen.width / x, Screen.height / y, Screen.width / c / VidaCheia * playerControlle1.vida, Screen.height / a), Sangue1);

        if (playerControlle1.temAtaque>=1)
            GUI.DrawTexture(new Rect(Screen.width / x1, Screen.height / y1, Screen.width / c1, Screen.height / a1), umAtaque);
        if (playerControlle1.temAtaque >= 2)
            GUI.DrawTexture(new Rect(Screen.width / x2, Screen.height / y1, Screen.width / c2, Screen.height / a1), doisAtaque);
        if (playerControlle1.temAtaque >= 3)
            GUI.DrawTexture(new Rect(Screen.width / x3, Screen.height / y1, Screen.width / c2, Screen.height / a1), tresAtaque);
    }
}


//x1 12.8f 11.1f 9.5f y 13.5f  a 66f c 69f 59.3f 59.3f  
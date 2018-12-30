using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour {

    public GameObject playerPrefab;
    public Transform player;
    private GameObject soldado;


    public float smooth;
    public Vector2 speed;
    public Vector2 newPosition2DCam;
    
    public bool venceu1;
    public bool venceu2;
    public bool arena1;
    public bool arena2;
    public bool criado1;
    public bool criado2;
    public GameObject parede;
    public GameObject porta;
    public GameObject bloqueio_porta;

    public AudioSource audio;
    public AudioClip somPorta;
    
    void Start () {
        venceu1 = false;
        venceu2 = false;
        arena1 = false;
        arena2 = false;
        criado1 = false;
        criado2 = false;
}
	
	void Update () {

        //area plataforma
        if (player.transform.position.x > -63.5f && player.transform.position.x < -21.3f)
        {
            if (Camera.main.orthographicSize < 5.8f) //Ajusta ate a distancia adequada
                Camera.main.orthographicSize += 1f * Time.deltaTime;
            newPosition2DCam.x = Mathf.SmoothDamp(transform.position.x, player.position.x + 4f, ref speed.x, smooth);
            newPosition2DCam.y = Mathf.SmoothDamp(transform.position.y, player.position.y + 0.7f, ref speed.y, smooth);
            Vector3 newPositionCam = new Vector3(newPosition2DCam.x, newPosition2DCam.y, -10);
            transform.position = Vector3.Slerp(transform.position, newPositionCam, Time.time);
        }

            //arena1
        else if (player.transform.position.x > 29.58f && player.transform.position.x < 45f && !venceu1)
        {
            if (Camera.main.orthographicSize < 5.32f) //Ajusta ate a distancia adequada
                Camera.main.orthographicSize += 1f * Time.deltaTime;
            if (!criado1)
            {
                soldado = Instantiate(playerPrefab) as GameObject;
                soldado.transform.position = new Vector2(41f, 2f);
                criado1 = true;
            }

            if (soldado.GetComponent<playerControlle3>().morto)
            {
                venceu1 = true;
                Destroy(parede.transform.gameObject);
            }
            
            newPosition2DCam.x = Mathf.SmoothDamp(transform.position.x, 36.53f, ref speed.x, smooth); //36.53
            newPosition2DCam.y = Mathf.SmoothDamp(transform.position.y, 3.1f, ref speed.y, smooth);//3.1
            Vector3 newPositionCam = new Vector3(newPosition2DCam.x, newPosition2DCam.y, -10);
            transform.position = Vector3.Slerp(transform.position, newPositionCam, Time.time);
            
        }

        //arena2
        else if (player.transform.position.x > 82.7f && !venceu2)
        {
            if (Camera.main.orthographicSize < 5.8f) //Ajusta ate a distancia adequada
                Camera.main.orthographicSize += 1f * Time.deltaTime;

            if (!criado2) // cria o soldado
            {
                soldado = Instantiate(playerPrefab) as GameObject;
                soldado.transform.position = new Vector2(94f, 6f);
                criado2 = true;
            }

            if (soldado.GetComponent<playerControlle3>().morto)
            {
                venceu2 = true;
                // comando de abrir a porta x96.3 y0
                audio.PlayOneShot(somPorta);
                porta.transform.position = new Vector3(96.3f, porta.transform.position.y, 0.09f);
                porta.transform.Rotate(0, 180, 0);
                Destroy(bloqueio_porta.transform.gameObject);
            }


            newPosition2DCam.x = Mathf.SmoothDamp(transform.position.x, 90f, ref speed.x, smooth); //89.6 posicao x da camera
            newPosition2DCam.y = Mathf.SmoothDamp(transform.position.y, 6f, ref speed.y, smooth);//6 posicao y da camera
            Vector3 newPositionCam = new Vector3(newPosition2DCam.x, newPosition2DCam.y, -10);
            transform.position = Vector3.Slerp(transform.position, newPositionCam, Time.time);

        }
        
        //camera normal
        else
        {
            if (Camera.main.orthographicSize > 5.0f)
                Camera.main.orthographicSize -= 1f * Time.deltaTime;
            newPosition2DCam.x = Mathf.SmoothDamp(transform.position.x, player.position.x + 3f, ref speed.x, smooth);
            newPosition2DCam.y = Mathf.SmoothDamp(transform.position.y, player.position.y + 0.7f, ref speed.y, smooth);
            Vector3 newPositionCam = new Vector3(newPosition2DCam.x, newPosition2DCam.y, -10);
            transform.position = Vector3.Slerp(transform.position, newPositionCam, Time.time);
        }
        
    }
}

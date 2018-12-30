using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlle3 : MonoBehaviour
{

    public GameObject ataquePrefab;
    public Animator anime;
    public Rigidbody2D playerRigidbory;

    public bool correndo;
    public bool atacando;
    public bool morrendo;
    public bool morto;

    public float speed;
    private float x;
    private int direcao = 1;
    public int forceJump;

    //verifica o chao
    public Transform contatoChao3;
    public bool pisandoChao;
    public LayerMask oqueEhChao;

    private float tempoCorrente;
    public float tempoAtaque;
    private float tempoSom = 0.2f;
    private float tempoCorrenteSom;
    private bool ataqueIniciado;
    public float tempoMorrendo;

    //Audio
    public AudioSource audio;
    public AudioClip somPulando;
    public AudioClip somCorrendo;
    public AudioClip somAtacando;
    public AudioClip somDanoEspada;
    public AudioClip somMorrendo;

    void Start()
    {
        tempoCorrente = -1.0f;
        ataqueIniciado = false;
    }


    void Update()
    {
        x = transform.position.x;

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA ESQUERDA
        if (Input.GetButton("Esquerda2") && !Input.GetButton("Direita2") && (!atacando || !pisandoChao) && !morrendo)
        {
            x -= speed * Time.deltaTime;
            transform.position = new Vector2(x, transform.position.y);
            if (direcao == 2)
            {
                transform.position = new Vector2(x - 0.48f, transform.position.y);
                transform.Rotate(0, 180, 0);
                direcao = 1;
            }
        }
        //VERIFICA DIREITA
        if (Input.GetButton("Direita2") && !Input.GetButton("Esquerda2") && (!atacando || !pisandoChao) && !morrendo)
        {
            x += speed * Time.deltaTime;
            transform.position = new Vector2(x, transform.position.y);
            if (direcao == 1)
            {
                transform.position = new Vector2(x + 0.48f, transform.position.y);
                transform.Rotate(0, 180, 0);
                direcao = 2;
            }
        }
        //VERIFICA ESQUERDA/DIREITA ANIMACAO CORRENDO
        if ((Input.GetButton("Esquerda2") || Input.GetButton("Direita2")) && !(Input.GetButton("Esquerda2") && Input.GetButton("Direita2")) && !atacando && !morrendo)
        {
            tempoCorrenteSom += Time.deltaTime;
            if (tempoCorrenteSom > tempoSom && pisandoChao)
            {
                audio.PlayOneShot(somCorrendo);
                tempoCorrenteSom = 0;
            }
            correndo = true;
        }
        else correndo = false;

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA PULO
        if (Input.GetButtonDown("Pulo2") && !atacando && !morrendo && pisandoChao)
        {
            audio.PlayOneShot(somPulando);
            playerRigidbory.AddForce(new Vector2(0, forceJump));
        }
        pisandoChao = Physics2D.OverlapCircle(contatoChao3.position, 0.2f, oqueEhChao);

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA ATAQUE
        if (Input.GetButtonDown("Ataque2") && !morrendo && !atacando)
        {
            tempoCorrente = 0;
            atacando = true;
        }
        if (atacando)
        {
            tempoCorrente += Time.deltaTime;

            if (!ataqueIniciado && tempoCorrente >= tempoAtaque - 0.06f && !morrendo)
            {
                audio.PlayOneShot(somAtacando);
                ataqueIniciado = true;
                GameObject tempPrefab = Instantiate(ataquePrefab) as GameObject;
                if (direcao == 2)
                    tempPrefab.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.1f);
                else tempPrefab.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.1f);
            }
            if (tempoCorrente >= tempoAtaque) //finaliza o ataque
            {
                atacando = false;
                ataqueIniciado = false;

            }
        }

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA MORRENDO
        if (morrendo)
        {
            tempoCorrente += Time.deltaTime;
            if (tempoCorrente >= tempoMorrendo)
            {
                //morrendo = false;
                morto = true;
            }
            if (morto && tempoCorrente > 5)
                Destroy(transform.gameObject);
        }
        if (transform.position.y < -5f && !morrendo)
        {
            
            morrendo = true;
            tempoCorrente = 0;
        }

        //--------------------------------------------------------------------------------------------------------------------------


        anime.SetBool("pulando", !pisandoChao);
        anime.SetBool("correndo", correndo);
        anime.SetBool("morrendo", morrendo);
        anime.SetBool("atacando", atacando);
        anime.SetBool("morto", morto);

    }

    private void OnTriggerEnter2D()
    {

        if (!morrendo)
        {
            audio.PlayOneShot(somMorrendo);
            audio.PlayOneShot(somDanoEspada);
            morrendo = true;
            tempoCorrente = 0;
        }
    }

}
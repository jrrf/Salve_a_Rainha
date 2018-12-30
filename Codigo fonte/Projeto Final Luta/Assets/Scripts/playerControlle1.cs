using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControlle1 : MonoBehaviour {

    public GameObject ataquePrefab;
    public Animator anime;
    public Rigidbody2D playerRigidbory;

    //Ataque especial
    public GameObject ataqueEspecial;
    public float forcaTiro;
    public static int temAtaque;
    public Transform spawnEspecial;

    public bool correndo;
    public bool atacando;
    public bool morrendo;
    public bool morto;
    public bool dano;

    public float speed;
    private float x;
    private int direcao;
    public int forceJump;

    //verifica o chao
    public Transform contatoChao1;
    public bool pisandoChao;
    public LayerMask oqueEhChao;

    private float tempoCorrente;
    public float tempoAtaque;
    private float tempoSom;
    private float tempoCorrenteSom;
    public static int vida;
    public static float posicaoY;
    private bool ataqueIniciado;
    public float tempoMorrendo;

    //Audio
    public AudioSource audio;
    public AudioClip somPulando;
    public AudioClip somCorrendo;
    public AudioClip somDano;
    public AudioClip somDanoEspada;
    public AudioClip somAtacando;
    public AudioClip somMorrendo;
    public AudioClip somPocao;

    void Start () {
        temAtaque = 0;
        direcao = 2;
        tempoSom = 0.2f;
        vida = PlayerPrefs.GetInt("vida");
        PlayerPrefs.SetInt("vida", 100);
        tempoCorrente = -1.0f;
        ataqueIniciado = false;
        tempoCorrenteSom = 0;
    }


    void Update()
    {
        x = transform.position.x;
        posicaoY = transform.position.y;

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA ESQUERDA
        if (Input.GetButton("Esquerda1") && !Input.GetButton("Direita1") && (!atacando || !pisandoChao) && !morrendo && !dano)
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
        if (Input.GetButton("Direita1") && !Input.GetButton("Esquerda1") && (!atacando || !pisandoChao) && !morrendo && !dano)
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
        if ((Input.GetButton("Esquerda1") || Input.GetButton("Direita1")) && !(Input.GetButton("Esquerda1") && Input.GetButton("Direita1")) && !atacando && !morrendo && !dano)
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
        if (Input.GetButtonDown("Pulo1") && !atacando && !morrendo && pisandoChao)
        {
            audio.PlayOneShot(somPulando);
            playerRigidbory.AddForce(new Vector2(0, forceJump));
        }
        pisandoChao = Physics2D.OverlapCircle(contatoChao1.position, 0.2f, oqueEhChao);

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA ATAQUE
        if (Input.GetButtonDown("Ataque1") && !morrendo && !dano && !atacando)
        {
            tempoCorrente = 0;
            atacando = true;
        }
        if (atacando)
        {
            tempoCorrente += Time.deltaTime;

            if (!ataqueIniciado && tempoCorrente >= tempoAtaque - 0.06f && !dano)
            {

                audio.PlayOneShot(somAtacando);
                ataqueIniciado = true;
                GameObject tempPrefab = Instantiate(ataquePrefab) as GameObject;
                if (direcao == 2)
                    tempPrefab.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y-0.1f);
                else tempPrefab.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y-0.1f);
            }
            if (tempoCorrente >= tempoAtaque) //finaliza o ataque
            {
                atacando = false;
                ataqueIniciado = false;

            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        //VERIFICA ATAQUE ESPECIAL
        if (Input.GetButtonDown("Especial1") && temAtaque > 0 && !morrendo && !dano && !atacando)
        {
            atirar();
        }

            //--------------------------------------------------------------------------------------------------------------------------
            //VERIFICA MORRENDO
            if (vida < 10 && !morrendo)
        {
            audio.PlayOneShot(somMorrendo);
            tempoCorrente = 0;
            morrendo = true;
            dano = false;
        }

        if (morrendo)
        {
            tempoCorrente += Time.deltaTime;
            if (tempoCorrente >= tempoMorrendo)
            {
                //morrendo = false;
                morto = true;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------

        //VERIFICA DANO
        if (dano)
        {
            tempoCorrente += Time.deltaTime;
            if (tempoCorrente >= tempoAtaque)
            {
                dano = false;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------


        if(Input.GetKeyDown("escape"))
            SceneManager.LoadScene("MenuInicial");

        anime.SetBool("pulando", !pisandoChao);
        anime.SetBool("correndo", correndo);
        anime.SetBool("dano", dano);
        anime.SetBool("morrendo", morrendo);
        anime.SetBool("atacando", atacando);
        anime.SetBool("morto", morto);

    }
    

    public void atirar()
    {
        GameObject prefabArma = Instantiate(ataqueEspecial) as GameObject;

        prefabArma.transform.position = spawnEspecial.position;
        //Adicionando a força do tiro
        if(direcao==1)
            prefabArma.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forcaTiro, 0));
        else prefabArma.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaTiro, 0));
        temAtaque--;
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "pocaoAtaque")
        {
            Destroy(colisor.gameObject);
            audio.PlayOneShot(somPocao);
            temAtaque++;
            if (temAtaque > 3)
                temAtaque = 3;
        }

        else if (colisor.gameObject.tag == "pocaoVida")
        {
            vida += 20;
            if (vida > 100)
                vida = 100;
            Destroy(colisor.gameObject);
            audio.PlayOneShot(somPocao);
        }

        else if (!dano)
        {
            audio.PlayOneShot(somDano);
            dano = true;
            if (vida > 0)
                vida-=10;
            atacando = false;
            tempoCorrente = 0;

            if (colisor.gameObject.tag == "Player")
                audio.PlayOneShot(somDanoEspada);

            else if (colisor.gameObject.tag == "ataqueEspecial")
            {
                Destroy(colisor.gameObject);
                audio.PlayOneShot(somDanoEspada);
                if (vida > 0)
                    vida -= 10;
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        switch(colisor.gameObject.tag)
        {
            case "plataformaMovel2":
                transform.parent = colisor.gameObject.transform;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D colisor)
    {
        switch (colisor.gameObject.tag)
        {
            case "plataformaMovel2":
                transform.parent = null;
                break;
        }
    }

}


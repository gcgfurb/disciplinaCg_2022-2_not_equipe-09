using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour {
    private ControleJogo controleJogo1;
    private Rigidbody2D rBody;

    private bool noChao = true;
    public bool ataque;
    public bool seMovendo;
    bool enemyInRange;

    public float horizontal;
    public int dano = 10;
    public float vertical;

    public bool atacando;

    Vector2 velocidade;

    private bool direita = true;
    //EnemyHealth enemyHealth;

    private Animator animator;


    // Use this for initialization
    void Start () {

        animator = gameObject.GetComponent<Animator>();

        controleJogo1 = FindObjectOfType(typeof(ControleJogo)) as ControleJogo;

        rBody = GetComponent<Rigidbody2D>();

       // enemyHealth = FindObjectOfType(typeof(EnemyHealth)) as EnemyHealth;
    }
	
	// Update is called once per frame
	void Update () {

        moveJogador();

    }


    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        velocidade = new Vector2(horizontal * controleJogo1.velocidadePersonagem, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = velocidade;

    }

    void LateUpdate()
    {


    }

    void moveJogador() //Movimentacao do sprit do presonagem 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float velocidade = controleJogo1.velocidadePersonagem;

        Vector2 velocidadeAgora = rBody.velocity = new Vector2(horizontal * velocidade, vertical * velocidade);

        if (transform.position.y > controleJogo1.limiteMaximoY)
        {
            transform.position = new Vector3(transform.position.x, controleJogo1.limiteMaximoY, 0);
        }
        else if(transform.position.y < controleJogo1.limiteMinimoY)
        {
            transform.position = new Vector3(transform.position.x, controleJogo1.limiteMinimoY, 0);
        }
    }

    void virarJogador()
    {
        direita = !direita;

        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        transform.localScale = novoScale;
    }

}

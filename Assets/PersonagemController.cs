using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonagemController : MonoBehaviour
{
    public GameObject groundCheck;
    public Rigidbody2D rb2d; 
    public float vel;
    public float jumpForce;
    public TMP_Text pontuacao;
    private int points = 0;
    
    private Animator anim; 
    private GroundCheck groundCheckScript;    

    // NOVAS VARIÁVEIS PARA O TEMPO PARADO
    private float tempoParado = 0f;
    private const float TEMPO_PARA_ANIMAÇÃO = 5f;

    public void AddToPoints(int x)
    {
        points += x;
        pontuacao.text = "Pontuação: " + points.ToString();
    }

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>(); 
        groundCheckScript = groundCheck.GetComponent<GroundCheck>();
        pontuacao.text = "Pontuação: 0";
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        if(rb2d.velocity.magnitude < 5){
            rb2d.velocity += new Vector2(vel,0) * moveHorizontal * Time.deltaTime;
        }
        
        if(Input.GetKey(KeyCode.Space) && groundCheckScript.isOnGround){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        // CONTROLANDO AS ANIMAÇÕES DE ANDAR E PARAR
        if (moveHorizontal != 0)
        {
            anim.SetBool("isWalking", true);
            // Se ele se mexer, o cronômetro zera e desativa a animação especial
            tempoParado = 0f;
            anim.SetBool("isRippingPants", false);
        }
        else
        {
            anim.SetBool("isWalking", false);

            // Se ele estiver no chão e parado, o cronômetro começa a contar
            if (groundCheckScript.isOnGround)
            {
                tempoParado += Time.deltaTime;

                // Se o tempo parado passar de 5 segundos, ativa o gatilho
                if (tempoParado >= TEMPO_PARA_ANIMAÇÃO)
                {
                    anim.SetBool("isRippingPants", true);
                }
            }
        }

        // Se pular, também cancela a animação especial imediatamente
        if (!groundCheckScript.isOnGround)
        {
            tempoParado = 0f;
            anim.SetBool("isRippingPants", false);
        }

        // Avisa se está no chão e passa a velocidade
        anim.SetBool("isGrounded", groundCheckScript.isOnGround);
        anim.SetFloat("vVelocity", rb2d.velocity.y);

        // CÓDIGO PARA VIRAR O BOB ESPONJA
        if (moveHorizontal > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
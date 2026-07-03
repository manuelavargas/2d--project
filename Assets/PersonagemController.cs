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
    public void AddToPoints(int x)
    {
        points += x;
        pontuacao.text = "Pontuação: " + points.ToString();
    }
    // Start is called before the first frame update
    private GroundCheck groundCheckScript;    

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        groundCheckScript = groundCheck.GetComponent<GroundCheck>();
        pontuacao.text = "Pontuação: 0";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(rb2d.velocity.magnitude < 5){
        rb2d.velocity += new Vector2(vel,0) *moveHorizontal * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.Space) && groundCheckScript.isOnGround){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float speed = 10f; // vitesse du character
    public float airSpeed= 1.5f;
    public float gravityScale = 9f;
    public float gravityScaleMultiplier = 2f;
    private float moveInput ;

    private Rigidbody2D rb;
    private bool isGrounded; // vérification si character touche le ground
    //public Transform feetPos;
    //public float checkRadius;

    [Header("Jump")] 
    public float jumpForce = 30f; // force appliquer lors du saut
    public float timeToAscend = 0.2f;
    public float gravityToAscend = 1f;
    private int extrajumps; 
    public int extraJumpsValue = 1;// permet d'avoir des sauts extra
    
    [Header("Jump over time")] 
    public float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    [Header("Coyote Jump")] 
    public bool isCoyotejump = false;
    public float coyoteTime = 0.1f; // permet de varier le temps du saut
    private bool facingRight = true;
    
    [Header("Checks")]
    public GameObject raycastStrike;
    public GameObject raycastSaut;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask strikeLayerMask;

    void Start()
    {
        extrajumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    // physics of the game
    void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, platfomLayerMask);

        moveInput = Input.GetAxis("Horizontal");
        
        if (isGrounded == false) // airspeed
        {
            rb.velocity = new Vector2(moveInput * (speed/airSpeed), rb.velocity.y);
        }
        else // ground speed
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
       
    }
    
    void Update()
    {
        Strike();
        Jump();
        
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    #region Jump
    void Jump()
    {
        bool wasGrounded = isGrounded;
        
        Debug.DrawRay(raycastSaut.transform.position, transform.TransformDirection(Vector2.down) * 0.3f, Color.white, 0.2f);
        RaycastHit2D hit2 = Physics2D.Raycast(raycastSaut.transform.position, transform.TransformDirection(Vector2.down), 0.3f, groundLayerMask);

        if (hit2)
        {
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
            if (wasGrounded)
            {
                StartCoroutine(CoyoteTimeJump());
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = gravityScale * gravityScaleMultiplier;
            Debug.Log("Coucou");
        }
        else
        {
            rb.gravityScale = gravityScale;
            Debug.Log("Salope");
        }
        
        if (isGrounded == true) {
            extrajumps = extraJumpsValue; // reprise de la valeur des jump quand character touche le ground
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && extrajumps > 0)
        {
            if (isGrounded == true)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce; // Jump
                StartCoroutine(GravityJump());
                //extrajumps --; // reduce the counter of jumps when not grounded // A décocher pour le double saut
            }
            else
            {
                if (isCoyotejump == true) // Coyote Jump
                {
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                    rb.velocity = Vector2.up * jumpForce; // Jump
                }
            }
        }
        /*
        else if(Input.GetKeyDown(KeyCode.Space) && extrajumps == 0 && isGroundedBox == true) // Le double saut dispo, il faut juste l'enlever des commentaires
        {
            
            rb.velocity = Vector2.up * jumpForce;
            extrajumps++;
        }
        */
        // START Jump higher over time 
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0 && isJumping ==true)
            {
                rb.velocity = Vector2.up * jumpForce ;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        //  END Jump higher over time 
    }

    IEnumerator CoyoteTimeJump() // check pendant .1s si le joueur vien de quitter une plateforme
    {
        isCoyotejump = true;
        yield return new WaitForSeconds(coyoteTime);
        isCoyotejump = false;
    }
    
    IEnumerator GravityJump() // check pendant .1s si le joueur vien de quitter une plateforme
    {
        rb.gravityScale = gravityToAscend;
        yield return new WaitForSeconds(timeToAscend);
        rb.gravityScale = gravityScale;
    }
    #endregion
    
    void Strike() // Tire un raycast a droite ou a gauche en fonction du Flip du Player, permettra de frapper un ennemi
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && facingRight == true) //strike droit
        {
            Debug.DrawRay(raycastStrike.transform.position, transform.TransformDirection(Vector2.right) * 2f, Color.green, .5f);
            RaycastHit2D hit = Physics2D.Raycast(raycastStrike.transform.position, transform.TransformDirection(Vector2.right), 2f, strikeLayerMask);
            if (hit)
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.green; // Colori le Sprite toucher
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && facingRight == false)//strike gauche
        {
            Debug.DrawRay(raycastStrike.transform.position, transform.TransformDirection(Vector2.left) * 2f, Color.green, .5f);
            RaycastHit2D hit = Physics2D.Raycast(raycastStrike.transform.position, transform.TransformDirection(Vector2.left), 2f, strikeLayerMask);
            if (hit)
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.green;// Colori le Sprite toucher
            }

        }
    }

    public void ChoperParUnePlante()
    {
        rb.velocity = new Vector2(0, 0);
    }
}

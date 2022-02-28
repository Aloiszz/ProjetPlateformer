using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float speed = 10f; // vitesse de déplacement quand grounded
    public float airSpeed = 1.5f; // maniabilité de déplacement quand non grounded
    private float moveInput ;
    
    [Header("Gravity")] [Tooltip("permet d'agir sur la gravité du player")]
    public float gravityScale = 9f; // gravité de base 
    public float gravityScaleMultiplier = 2f; // multiplication de la gravité
    public float batiffolementDesAiles = 1f; // permet de floter quelque seconde de plus a la fin du saut 
    public float gravityMaxSpeed = 15f; // valeur doit etre négative, vitesse max de déscente
    public float gravityScaleMax = 17f; // application maximum de la gravité
    

    [Header("Jump")] 
    public float jumpForce = 30f; // force appliquer lors du saut
    private int extrajumps; 
    public int extraJumpsValue = 1;// Permet un saut suplémentaire
    
    [Header("Jump over time")] 
    public float jumpTime; // temps que l'on reste en l'air quand "Space Bar" est enclenché
    private float jumpTimeCounter;
    private bool isJumping;

    [Header("Coyote Jump")] 
    public bool isCoyotejump = false;// permet de vérifier si le player est dans le vide
    public float coyoteTime = 0.1f; // permet de varier le temps du saut

    [Header("Checks")]
    public GameObject raycastStrike;
    [SerializeField] private LayerMask strikeLayerMask;
    public GameObject raycastSaut1;
    public GameObject raycastSaut2;
    [SerializeField] private LayerMask groundLayerMask;
    
    public Rigidbody2D rb; // rigidbody 2D
    private Collider2D coll; // collision du Player
    private bool isGrounded; // vérification si character touche le ground
    private bool facingRight = true; // Permet de vérifier quel est la direction du player

    void Start()
    {
        extrajumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        rb.gravityScale = gravityScale;
    }

    // physics of the game
    void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, platfomLayerMask);

        moveInput = Input.GetAxis("Horizontal"); // permet le déplacement du Player
        
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
    } // Permet de vérifier quel est la direction du player


    #region Jump
    void Jump()
    {
        bool wasGrounded = isGrounded;
        
        Debug.DrawRay(raycastSaut1.transform.position, transform.TransformDirection(Vector2.down) * 0.25f, Color.white, 0.2f);
        Debug.DrawRay(raycastSaut2.transform.position, transform.TransformDirection(Vector2.down) * 0.25f, Color.white, 0.2f);
        RaycastHit2D hit1 = Physics2D.Raycast(raycastSaut1.transform.position, transform.TransformDirection(Vector2.down), 0.25f, groundLayerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(raycastSaut2.transform.position, transform.TransformDirection(Vector2.down), 0.25f, groundLayerMask);
        
        if (hit1 ||hit2)
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

        #region Jump Gravity // permet de gérer la déscente du perso lors du saut (plus de gravité)
        if (rb.velocity.y < 0) // si joueur tombe alors applique gravityMultiplier sauf si il garde "espace" enfoncé
        {
            if (Input.GetKey(KeyCode.Space) == true)
            {
                rb.gravityScale = gravityScale - batiffolementDesAiles;
            }
            else
            {
                rb.gravityScale = gravityScale * gravityScaleMultiplier;
                if (rb.velocity.y < gravityMaxSpeed)
                {
                    rb.gravityScale = gravityScaleMax;
                }
            }
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
        #endregion
        
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
                
                //StartCoroutine(GravityJump());
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

        #region Jump higher over time 
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0 && isJumping ==true)
            {
                //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                rb.velocity = Vector2.up * jumpForce;
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
        #endregion 
    }

    IEnumerator CoyoteTimeJump() // check pendant .1s si le joueur vien de quitter une plateforme
    {
        isCoyotejump = true;
        yield return new WaitForSeconds(coyoteTime);
        isCoyotejump = false;
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

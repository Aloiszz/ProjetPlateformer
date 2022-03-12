using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float speed = 10f; // vitesse de déplacement quand grounded
    public float airSpeed = 1.5f; // maniabilité de déplacement quand non grounded
    private float moveInput;
    
    [Header("Gravity")] [Tooltip("permet d'agir sur la gravité du player")]
    public float gravityScale = 9f; // gravité de base 
    public float gravityScaleMultiplier = 2f; // multiplication de la gravité
    public float gravityPlannage = 1f; // permet de floter quelque seconde de plus a la fin du saut 
    public float gravityMaxSpeedFall = 15f; // valeur doit etre négative, vitesse max de déscente
    public float gravityScaleMax = 17f; // application maximum de la gravité

    private bool isPlannage = false;
    
    [Header("Jump")] 
    public float jumpForce = 30f; // force appliquer lors du saut
    public float jumpForceDouble;
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
    
    [HideInInspector] public Rigidbody2D rb; // rigidbody 2D
    private Collider2D coll; // collision du Player
    private bool isGrounded; // vérification si character touche le ground
    public bool facingRight = true; // Permet de vérifier quel est la direction du player
    
    [Header("Animation")]
    public Animator animator;
    public bool CanWalk2;
    public bool CanJump2;
    public bool IsFalling2;

    public static CharacterMovement instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

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

        moveInput = Input.GetAxisRaw("Horizontal"); // permet le déplacement du Player

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
        //Debug.Log(isPlannage);
        //Animations --------
        
        if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            CanWalk2 = true;
        }
        else
        {
            CanWalk2 = false;
        }
        
        animator.SetBool("CanWalk",CanWalk2);
        // Animations ---------
        
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(raycastSaut1.transform.position, transform.TransformDirection(Vector2.down) * 0.25f);
        Gizmos.DrawRay(raycastSaut2.transform.position, transform.TransformDirection(Vector2.down) * 0.25f);
    }

    #region Jump
    void Jump()
    {
        bool wasGrounded = isGrounded;
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
            if (Input.GetButton("JumpGamepad") == true) 
            {
                rb.gravityScale = gravityScale - gravityPlannage;
                isPlannage = true;
            }
            else
            {
                rb.gravityScale = gravityScale * gravityScaleMultiplier;
                //rb.gravityScale = gravityScaleMultiplier;
                if (rb.velocity.y < gravityMaxSpeedFall)
                {
                    rb.gravityScale = gravityScaleMax;
                }
            }
        }
        else
        {
            rb.gravityScale = gravityScale;
            isPlannage = false;
        }
        #endregion
        
        if (isGrounded == true) {
            extrajumps = extraJumpsValue; // reprise de la valeur des jump quand character touche le ground
        }
        Debug.Log(isGrounded);
        if (Input.GetButtonDown("JumpGamepad"))
        {
            if (isGrounded == true)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                //rb.velocity = Vector2.up * jumpForce;// Jump
                //StartCoroutine(GravityJump());
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
        if (Input.GetButtonDown("DoubleJumpGamepad") && isGrounded == false && extrajumps > 0) // Le double Saut
        {
            if (isPlannage)
            {
                isJumping = false;
                extrajumps --;
                rb.velocity = Vector2.up * jumpForceDouble;
            }
        }
        
        #region Jump higher over time 
        if (Input.GetButton("JumpGamepad")) 
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
        if (Input.GetButtonUp("JumpGamepad"))
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
}

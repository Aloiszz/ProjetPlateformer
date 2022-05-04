using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using XInputDotNetPure;

public class CharacterMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float speed = 10f; // vitesse de déplacement quand grounded
    public float airSpeed = 1.5f; // maniabilité de déplacement quand non grounded
    private float moveInput;
    [HideInInspector] public bool canMove = true;
    
    [Header("Gravity")] [Tooltip("permet d'agir sur la gravité du player")]
    public float gravityScale = 9f; // gravité de base 
    public float gravityScaleMultiplier = 2f; // multiplication de la gravité
    public float gravityPlannage = 1f; // permet de floter quelque seconde de plus a la fin du saut 
    public float gravityMaxSpeedFall = 15f; // valeur doit etre négative, vitesse max de déscente
    public float gravityScaleMax = 17f; // application maximum de la gravité
    public bool isGravityMultiplier = false;

    public bool isPlannage = false;
    
    [Header("Jump")] 
    public float jumpForce = 30f; // force appliquer lors du saut
    public float jumpForceDouble;
    public int extrajumps; 
    public int extraJumpsValue = 1;// Permet un saut suplémentaire
    public bool canJump = true;

    [Header("Jump over time")] 
    public float jumpTime; // temps que l'on reste en l'air quand "Space Bar" est enclenché
    private float jumpTimeCounter;
    private bool isJumping;
    public bool isJumpingSingle;

    [Header("Coyote Jump")] 
    public bool isCoyotejump = false;// permet de vérifier si le player est dans le vide
    public float coyoteTime = 0.1f; // permet de varier le temps du saut
    
    [Header("Jump Buffering")] 
    public float jumpBufferTime = 0.2f;// permet de vérifier si le player est dans le vide
    public float jumpBufferCounter; // permet de varier le temps du saut

    [Header("Checks")]
    public GameObject raycastStrike;
    [SerializeField] private LayerMask strikeLayerMask;
    public GameObject raycastSaut1;
    public GameObject raycastSaut2;
    [SerializeField] private LayerMask groundLayerMask;
    
    [HideInInspector] public Rigidbody2D rb; // rigidbody 2D
    private Collider2D coll; // collision du Player
    public bool isGrounded; // vérification si character touche le ground
    public bool facingRight = true; // Permet de vérifier quel est la direction du player
    
    [Header("Animation")]
    public Animator animator;
    public float stretch;
    public bool stopStretch;
    public bool isWalking;
    
    [Header("SFX")]
    public GameObject LineRenderPlannage_1;
    public GameObject LineRenderPlannage_2;
    public Light2D lightDoubleSaut;
    public Light2D lightDoubleSaut2;
    public ParticleSystem particlesDoubleSaut;
    public ParticleSystem particlesSaut;
    public ParticleSystem particlesLanding;
    public ParticleSystem particlesMarche;

    public ParticleSystem particlesSaut2;
    // public ParticleSystem particulesRetombée;
   // public ParticleSystem particulesRun;
   
   [Header("Floating")]
   private float y0;
   private Vector2 temp;
   public float amplitudeFloating;
   public float vitesseFloating;
   
   PlayerIndex playerIndex;
   GamePadState state;
   GamePadState prevState;
    
   [Header("Vibration Motor")]
   public float leftMotor;
   public float rightMotor;
   public float duration;
   
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

        if (canMove == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal"); // permet le déplacement du Player
        }

        if (isGrounded == false) // airspeed
        {
            rb.velocity = new Vector2(moveInput * (speed/airSpeed), rb.velocity.y);
            //rb.AddForce(new Vector2(moveInput * (speed/airSpeed) , rb.velocity.y), ForceMode2D.Impulse);
        }
        else // ground speed
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            //rb.AddForce(new Vector2(moveInput * speed, rb.velocity.y), ForceMode2D.Impulse);
        }
        
        
    }
    
    void Update()
    {
        if (isGrounded && rb.velocity.x !> 0)
        {
            particlesMarche.Play();
        }
        
        if (rb.velocity.y <= 0)
        {
            stopStretch = true;
        }
        else
        {
            stopStretch = false;
        }
        
        if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            animator.SetBool("IsWalking",true);
            isWalking = true;
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) < -0.1f)
            {
                animator.SetBool("IsWalking",true);
                isWalking = true;
            }
            animator.SetBool("IsWalking",false);
            isWalking = true;
        }
        
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            animator.SetBool("IsFalling",false);
            isWalking = false;
        }
        else
        {
            animator.SetBool("IsFalling",true);
            isWalking = true;
        }
        
        
        Strike();
        if (canJump == true)
        {
            Jump();
            if (!stopStretch)
            {
                transform.localScale = new Vector3(1 - rb.velocity.y * stretch, 1 + rb.velocity.y * stretch); 
            }
        }
        
        
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Quaternion Scaler = transform.localRotation;
        if (!facingRight)
        {
            Scaler.y = -180;
        }

        if (facingRight)
        {
            Scaler.y = 0;
        }
        transform.localRotation = Scaler;
    } // Permet de vérifier quel est la direction du player

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(raycastSaut1.transform.position, transform.TransformDirection(Vector2.down) * 0.09f);
        Gizmos.DrawRay(raycastSaut2.transform.position, transform.TransformDirection(Vector2.down) * 0.09f);
    }

    #region Jump
    void Jump()
    {
        bool wasGrounded = isGrounded;
        RaycastHit2D hit1 = Physics2D.Raycast(raycastSaut1.transform.position, transform.TransformDirection(Vector2.down), 0.09f, groundLayerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(raycastSaut2.transform.position, transform.TransformDirection(Vector2.down), 0.09f, groundLayerMask);
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
        if (rb.velocity.y < -1f) // si joueur tombe alors applique gravityMultiplier sauf si il garde "espace" enfoncé
        {
            animator.SetBool("IsFalling",true);
            animator.SetBool("isDoubleJumping", false);
            
            if (Input.GetButton("JumpGamepad") == true) 
            {
                if (isPlannage)
                {
                    temp.y = transform.position.y + amplitudeFloating *Mathf.Sin(vitesseFloating*Time.time);
                    transform.position = new Vector3(transform.position.x, temp.y, transform.position.z);
                    animator.SetBool("isPlanning", true);
                    isPlannage = true;
                    rb.velocity = new Vector2(rb.velocity.x, -2f);
                    //rb.gravityScale = gravityScale - gravityPlannage; 
                    Stamina.instance.UseStamina(35);
                    
                    LineRenderPlannage_1.SetActive(true);
                    LineRenderPlannage_2.SetActive(true);
                }
                else
                {
                    animator.SetBool("isPlanning", false);
                    rb.gravityScale = gravityScale * gravityScaleMultiplier;
                    if (rb.velocity.y < gravityMaxSpeedFall)
                    {
                        rb.gravityScale = gravityScaleMax;
                        isGravityMultiplier = true;
                        animator.SetBool("isGravityMultiplier", true);
                    }
                }
            }
            else
            {
                LineRenderPlannage_1.SetActive(false);
                LineRenderPlannage_2.SetActive(false);
                
                isPlannage = false;
                animator.SetBool("isPlanning", false);
                rb.gravityScale = gravityScale * gravityScaleMultiplier;
                //rb.gravityScale = gravityScaleMultiplier;
                if (rb.velocity.y < gravityMaxSpeedFall)
                {
                    rb.gravityScale = gravityScaleMax;
                    isGravityMultiplier = true;
                    animator.SetBool("isGravityMultiplier", true);
                    StartCoroutine(TimetoLandHard());
                    StartCoroutine(VibrationTime());
                }
            }
        }
        else
        {
            animator.SetBool("IsFalling",false);
            isGravityMultiplier = false;
            animator.SetBool("isGravityMultiplier", false);
            rb.gravityScale = gravityScale;
            isPlannage = false;
        }
        #endregion
        
        if (isGrounded == true) {
            extrajumps = extraJumpsValue; // reprise de la valeur des jump quand character touche le ground
            animator.ResetTrigger("IsJumping");
            animator.SetBool("isGrounded", true);
            animator.SetBool("isPlanning", false);
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isGravityMultiplier", false);
        }
        else
        {
            animator.SetTrigger("IsJumping");
            animator.SetBool("isGrounded", false);
        }
        
        isJumpingSingle = false;
        
        if (Input.GetButtonDown("JumpGamepad"))
        {
            jumpBufferCounter = jumpBufferTime;
            if (isGrounded == true)
            {
                particlesSaut.Play();
                particlesSaut2.Play();
                isJumpingSingle = true;
                isJumping = true;
                jumpTimeCounter = jumpTime;
                //rb.velocity = Vector2.up * jumpForce;// Jump
            }
            else
            {
                if (isCoyotejump == true) // Coyote Jump
                {
                    isJumpingSingle = true;
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                    rb.velocity = Vector2.up * jumpForce; // Jump
                }
            }
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        
        
        if (jumpBufferCounter > 0f)
        {
            //rb.velocity = Vector2.up * jumpForce;
            jumpBufferCounter = 0f;
        }
        
        if (Input.GetButtonDown("DoubleJumpGamepad") && isGrounded == false && extrajumps > 0 && !isCoyotejump) // Le double Saut
        {
            StartCoroutine(fadeInAndOut(true, 1));
            StartCoroutine(fadeInAndOut(false, 1));
            particlesDoubleSaut.transform.position = transform.position;
            
            /*angle = Mathf.Atan2(particlesDoubleSaut.transform.position.y - transform.position.y, particlesDoubleSaut.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, angle);
            angleParticules = angle;
            particlesDoubleSaut.shape.rotation.y = angleParticules;*/
            
            particlesDoubleSaut.Play();
            isJumping = false;
            extrajumps --;
            rb.velocity = Vector2.up * jumpForceDouble;
            animator.SetBool("isDoubleJumping", true);
            /*if (isPlannage == true)
            {
                isJumping = false;
                extrajumps --;
                rb.velocity = Vector2.up * jumpForceDouble;
                animator.SetBool("isDoubleJumping", true);
            }*/
        }
        
        #region Jump higher over time 
        if (Input.GetButton("JumpGamepad")) 
        {
            if (jumpTimeCounter > 0 && isJumping ==true)
            {
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

    IEnumerator TimetoLandHard()
    {
        speed = 0;
        canJump = false;
        yield return new WaitForSeconds(1);
        speed = 11;
        canJump = true;
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
    #endregion

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        //particulesRetombée.transform.position = transform.position;
        //particulesRetombée.Play();
    }*/

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

    IEnumerator fadeInAndOut(bool fadeIn, float duration)
    {
        float minLuminosity = 0; // min intensity
        float maxLuminosity = 1; // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
        }

        float currentIntensity = lightDoubleSaut.intensity;
        float currentIntensity2 = lightDoubleSaut2.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightDoubleSaut.intensity = Mathf.Lerp(a, b, counter / duration);
            lightDoubleSaut2.intensity = Mathf.Lerp(a, b, counter / duration);

            yield return null;
        }
    }
}

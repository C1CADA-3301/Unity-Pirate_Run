using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Rb;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpPower = 10f;
    [SerializeField] private float DoubleJumpPower = 10f;

    [SerializeField] private Transform GroundCheckSphere;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float CheckSphereRadius = 1f;

    [SerializeField] private GameObject SmokeParent;

    private bool IsGrounded = false;
    private bool Playerjumped = false;
    private bool CanDoubleJump = false;


    private bool GameStarted = false;

    private PlayerAnimation PlayerAnim;


    private BG_Scroller BG_Scroller_Ref;
    private PlayerHealthDamage PlayerShoot;
    


    private bool JumpRequest;
    private bool DoubleJumpRequest;

    private void Awake()
    {
        
        Rb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<PlayerAnimation>();
        PlayerShoot = GetComponent<PlayerHealthDamage>();
        BG_Scroller_Ref = GameObject.Find(Tags.Background).GetComponent<BG_Scroller>();
        SmokeParent = GameObject.Find(Tags.SmokeParent);
        SmokeParent.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }

  
    void Update()
    {
        if (GameStarted)
        {
            if (GameStarted && !GameManager.Game_Manager._Gameover)
            {

                PlayerMove();

            }
                if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded && CanDoubleJump)
            {
                DoubleJumpRequest = true;
            }

            if (Input.GetKey(KeyCode.Space) && IsGrounded)
            {
                JumpRequest = true;
                
            }

        }
    }

    private void FixedUpdate()
    {

        if (GameStarted && !GameManager.Game_Manager._Gameover)
        {

            //PlayerMove();
            GroundCheck();
            fall();
            if(JumpRequest)
            {
                PlayerJump();
                SoundManager.SoundManager_Instance.Jump_sfx();
                JumpRequest = false;
            }

            if(DoubleJumpRequest)
            {
                PlayerDoubleJump();
                SoundManager.SoundManager_Instance.Jump_sfx();
                DoubleJumpRequest = false;
            }
            
            
            //  Debug.Log(Rb.velocity.y);
        }
    }

    void PlayerMove()
    {
        Rb.velocity = new Vector3(MoveSpeed, Rb.velocity.y, 0f);
    }

    void GroundCheck()
    {
        IsGrounded = Physics.CheckSphere(GroundCheckSphere.position, CheckSphereRadius, GroundLayer);
        

        if(IsGrounded && Playerjumped)
        {
            Playerjumped = false;
            PlayerAnim.DidLand();
        }
       
       //Debug.Log("isgrounded = " + IsGrounded);
    }

    void PlayerJump()
    {
        Playerjumped = true;
        CanDoubleJump = true;
        PlayerAnim.DidJump();
        Rb.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Acceleration);
        Debug.Log("JUMP");

    }

    void PlayerDoubleJump()
    {
        //PlayerAnim.IsDoubleJump();
        Rb.AddForce(new Vector3(0, DoubleJumpPower, 0), ForceMode.Acceleration);
        CanDoubleJump = false;
        
        Debug.Log("Double JUMP");

    }

 

    void fall()
    {
        if(Rb.transform.position.y<=GameManager.Game_Manager.PlayerFallDistance)
        {
            Rb.constraints = RigidbodyConstraints.FreezePosition;
            GameManager.Game_Manager.GameOver();
        }

        
    }

    IEnumerator StartGame()
    {
        //PlayerAnim.PlayerIdle();
        yield return new WaitForSeconds(5f);
        
        GameStarted = true;
        PlayerAnim.PlayerRun();
        BG_Scroller_Ref.CanScroll = true;
        PlayerShoot.CanShoot = true;
        SmokeParent.SetActive(true);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GroundCheckSphere.position, CheckSphereRadius);
    }

}

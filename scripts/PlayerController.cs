using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;//liberary for restart of scene/game;
using UnityEngine.UI;//to interact with button
using UnityEngine;
using TMPro;
using UnityEditor;

// using System.Numerics;


public class PlayerController : MonoBehaviour
{
    //rigid body is related to gravity and mass.
     float count=0;
    public TextMeshProUGUI gameover;
    public Button restartbutton;
    public float jumpForce=500;
    public float gravityModifier=1; //9.8 gravity of earth
    public bool isOnGround=true;
    private Rigidbody playerRB;
    private Animator playerAnimation;
    public ParticleSystem explosion;
    public ParticleSystem dirtParticle;
    public bool gameOver=false;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    void Start()
    {
        Debug.Log("going");
        Physics.gravity*=gravityModifier;
        playerRB= GetComponent<Rigidbody>();//it is not like transform componet we should get the componet.
        playerAnimation=GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&isOnGround&& !gameOver)
        {
             dirtParticle.Stop();
        Physics.gravity*=gravityModifier;
          
         playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);//impulse calls imediatlty
             isOnGround=false;
             playerAnimation.SetTrigger("Jump_trig");
             audioSource.PlayOneShot(jumpSound,1.0f);
        }

    }
    public void OnCollisionEnter (Collision collision)//when collides with anything it is said to true;
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
        isOnGround=true;
        if(count==0)//when hitten the ground after hitting an obstacle in air and then if reaches ground it plays so to avoid that i have used count;
         {
          dirtParticle.Play();
         }
        
        }
        else if(collision.gameObject.CompareTag("obstacle"))
        {
            gameOver=true;
            if(count==0)
            {

            explosion.Play();
            }
             count++;
              dirtParticle.Stop();//sefsS
              
            playerAnimation.SetBool("Death_b",true);
            playerAnimation.SetInteger("DeathType_int",2);
            //  if(count==0)//just to avoid too many time to play particle explosion;
            //  {

            count++;

            //  }
             audioSource.PlayOneShot(hitSound,1.0f);

            gameover.gameObject.SetActive(true);
            restartbutton.gameObject.SetActive(true);


        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

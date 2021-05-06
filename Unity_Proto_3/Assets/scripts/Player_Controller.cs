using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifer;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem dirtFX;
    public ParticleSystem explosionFX;
    static public bool gameOver = false;

    private Rigidbody playerRb;
    bool isOnGround = true;
    Animator animator;
    AudioSource playerAudioSource;

    void Awake() {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void Start() {
        Physics.gravity *= gravityModifer;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            playerAudioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
        else if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int",1);
            explosionFX.Play();
            dirtFX.Stop();
            playerAudioSource.PlayOneShot(crashSound);
        }
    }
}

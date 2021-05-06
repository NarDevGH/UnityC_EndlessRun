using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour
{
    float speed = 30;
    float leftBoud = -15;

    private void Update() {
        if(Player_Controller.gameOver == false){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBoud){
            if(transform.CompareTag("Obstacle")){
                Destroy(gameObject);
            }
        }
    }
}

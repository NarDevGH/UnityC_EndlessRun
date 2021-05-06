using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    Vector3 spawnPos = new Vector3(25,0,0);
    float startDelay = 2;
    float repeatRate = 2;

    void Start() {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle(){
        if(Player_Controller.gameOver == false){
            Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
        }
    }
}

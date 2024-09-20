using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanManager : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject Obstacle;
    public GameObject []Obstacles;
    public Vector3 spwanPos=new Vector3(25,10,0);
    private float startDelay =2;
    private float interval=3;
    private PlayerController playerControllerScript;
    void Start()
    {
      playerControllerScript=GameObject.Find("ellie").GetComponent<PlayerController>();
      InvokeRepeating("spwanObstacle",startDelay,interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void spwanObstacle()
    {
      if(playerControllerScript.gameOver==false)
      {
        Instantiate(Obstacles[Random.Range(0,2)],spwanPos,Obstacles[Random.Range(0,2)].transform.rotation);

      }
        
    }
}

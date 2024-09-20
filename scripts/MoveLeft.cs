using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed=30;
    private float leftBound=-15;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript=GameObject.Find("ellie").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver==false)
        {
        transform.Translate(Vector3.left*Time.deltaTime*speed);

        }
        if(transform.position.x<leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
  
}

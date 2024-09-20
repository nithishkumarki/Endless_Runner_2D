using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    private float RepeatWidth;
    private Vector3 startLoc;
    void Start()
    {
        startLoc=transform.position;
        RepeatWidth=GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<(startLoc.x-RepeatWidth))
        {
          transform.position=startLoc;
        }
        
    }
}

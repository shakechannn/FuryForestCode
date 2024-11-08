using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.05f,0,0) ;
        if(transform.position.x < -18.8f)
        {
            transform.position = new Vector3(19,0,0);
        }
    }
}

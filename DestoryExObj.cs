using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryExObj : MonoBehaviour
{
    float DeleteTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeleteTime += Time.deltaTime;
        if (DeleteTime > 0.35f)
        {
            Destroy(gameObject);
        }
    }
}

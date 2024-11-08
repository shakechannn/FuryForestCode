using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.5f, 0f, 0f);

        if (transform.position.x > 15.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
            Debug.Log("Damage");
        }
    }

}

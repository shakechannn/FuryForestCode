using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    public AudioClip Destory;
    AudioSource audioSource;
    [SerializeField] GameObject Player;

    PlayerController playercontroller;
    ScoreController scorecontroller;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject obj = GameObject.Find("Capsule");
        GameObject scoreObj = GameObject.Find("Score");

        playercontroller = obj.GetComponent<PlayerController>(); 
        scorecontroller = scoreObj.GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-0.1f, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Wall")
        {
            if(collision.gameObject.tag == "Bullet")
            {
                playercontroller.EnemySound = true;
                scorecontroller.AddScore();
            }
            Destroy(gameObject);
        }
    }
}

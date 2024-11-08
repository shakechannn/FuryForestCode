using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnTitle : MonoBehaviour
{
    string backTitle = "TitleScene";
    string gameStart = "GameScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene(backTitle);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(gameStart);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(gameStart);
        }
    }
}

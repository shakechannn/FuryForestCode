using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int BossHp = 1000;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletPoint;
    int[,] move1Bullet = {
    { -60, -40, -20, 0, 20, 40, 60 },
    { -50, -30, -10, 10, 30, 50, 70 },
    };
    int randomBullet;
    int randomBullet2;
    int bossmove = 1;
    int bossmove4_1 = 0;
    string gameClear = "GameClear";

    ScoreController scoreController;
    BossBar bossBar;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        GameObject scoreObj = GameObject.Find("Score");
        GameObject bossbarObj = GameObject.Find("HPController");

        scoreController = scoreObj.GetComponent<ScoreController>();
        bossBar = bossbarObj.GetComponent<BossBar>();
        
        StartCoroutine(BossMoves());
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss.transform.position.y >= 4.0f) bossmove = -1;
        else if (Boss.transform.position.y <= -4.0f) bossmove = 1;
        transform.Translate(0, bossmove * 0.05f, 0);
        if (BossHp <= 0)
        {
            scoreController.AddBossScore();
            Destroy(gameObject);
            SceneManager.LoadScene(gameClear);
        }
    }

    IEnumerator BossMoves()
    {
        if (BossHp > 800 && BossHp <= 1000)
        {
            StartCoroutine(BossMove1());
        }
        else if (BossHp > 600 && BossHp <= 800)
        {
            StartCoroutine(BossMove2());
        }
        else if (BossHp > 400 && BossHp <= 600)
        {
            StartCoroutine(BossMove3());
        }
        else if (BossHp > 200 && BossHp <= 400)
        {
            StartCoroutine(BossMove4_2());
        }
        else if (BossHp > 0 && BossHp <= 200)
        {
            if (bossmove4_1 <= ((200-BossHp)/10))
            {
                Debug.Log(((200 - BossHp) / 10));
                StartCoroutine(BossMove4_1());
                StartCoroutine(BossMove4_2());
            }
            else
            {
                StartCoroutine(BossMove4_2());
            }
        }
        yield return null;
    }

    IEnumerator BossMove1()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 7; k++)
            {
                Instantiate(Bullet, BulletPoint.transform.position, Quaternion.Euler(0, 0, move1Bullet[(i % 2), k]));
            }
            yield return new WaitForSeconds(0.35f);
        }
        StartCoroutine(BossMoves());
    }

    IEnumerator BossMove2()
    {
        Debug.Log("Move2");
        randomBullet = Random.Range(-60, 60);
        Instantiate(Bullet, BulletPoint.transform.position, Quaternion.Euler(0, 0, randomBullet));
        yield return new WaitForSeconds(0.05f);

        StartCoroutine(BossMoves());
    }

    IEnumerator BossMove3()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(Bullet, BulletPoint.transform.position, Quaternion.Euler(0, 0, -30 + (i * 15)));
        }
        randomBullet = Random.Range(-30, 30);
        Instantiate(Bullet, BulletPoint.transform.position, Quaternion.Euler(0, 0, randomBullet));
        yield return new WaitForSeconds(0.35f);

        StartCoroutine(BossMoves());
    }

    IEnumerator BossMove4_1()
    {
        bossmove4_1++;
        while (true)
        {
            if (BossHp > 0 && BossHp <= 200)
            {
                randomBullet = Random.Range(-45, 45);
                Instantiate(Bullet, BulletPoint.transform.position, Quaternion.Euler(0, 0, randomBullet));
                yield return new WaitForSeconds(1.5f);
            }
            else break;
        }
    }

    IEnumerator BossMove4_2()
    {
        Debug.Log("Move2");
        randomBullet2 = Random.Range(-30, 30);
        for(int i = 0; i < 10; i++)
        {
            Instantiate(Bullet, BulletPoint.transform.position, Quaternion.Euler(0, 0, randomBullet2));
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.125f);
        StartCoroutine(BossMoves());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "ExplotionTag")
        {
            if (BossHp != 0) BossHp -= 20;
            bossBar.slider.value = BossHp;
            Debug.Log(BossHp);
        }
    }
}

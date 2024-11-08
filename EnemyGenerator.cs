using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject boss;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource1;

    int randomEnemy;
    int waveCount = 0;
    float timer = 0;
    float lange;
    bool BossSpawn = false;
    float[,] spawnSpan = { { 2, 3 }, { 0.7f, 1 }, { 0.6f, 0.7f } };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime + timer;
        if (timer <= 20)
        {
            waveCount = 0;
        }
        else if (timer <= 40 && timer > 20)
        {
            waveCount = 1;
        }
        else if (timer <= 60 && timer > 40)
        {
            waveCount = 2;
        }
        else if (timer >= 60 && BossSpawn == false)
        {
            BossSpawn = true;
            audioSource.Stop();  //New
            audioSource1.Play(); //New
            Debug.Log("boss");
            Invoke("Boss", 1f);
        }
    }
    IEnumerator EnemySpawn()
    {
        lange = Random.Range(-4.5f, 4.5f);
        randomEnemy = Random.Range(0, 2);
        switch (randomEnemy)
        {
            case 0:
                Instantiate(Enemy1, new Vector3(10, lange, 0), Quaternion.identity);
                yield return new WaitForSeconds(spawnSpan[waveCount, randomEnemy]);
                break;
            case 1:
                Instantiate(Enemy2, new Vector3(10, lange, 0), Quaternion.identity);
                yield return new WaitForSeconds(spawnSpan[waveCount, randomEnemy]);
                break;
        }
        if (timer >= 60)
        {

        }
        else
        {
            StartCoroutine(EnemySpawn());
        }
        yield return null;
    }

    public void Boss()
    {
        Instantiate(boss, new Vector3(7.5f, 0, 0), Quaternion.identity);
        BossBar bossBar;
        GameObject gameObject = GameObject.Find("HPController");
        bossBar = gameObject.GetComponent<BossBar>();

        bossBar.HPSpawn();
    }
}

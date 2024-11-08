using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class threeWay : MonoBehaviour
{
    [SerializeField] int wayNumber = 3;
    [SerializeField] Animator[] EnemyAttack;

    [SerializeField] GameObject Bullet;
    public int BulletType = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (BulletType == 0) StartCoroutine("BulletAttack");
        else StartCoroutine("NomalBullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BulletAttack()
    {
        float RandomWait = Random.Range(1f,3f);
        for (int i = 0; i < wayNumber; i++)
        {
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, -15 + (15 * i)));
        }
        EnemyAttack[1].SetTrigger("Attack 2");

        yield return new WaitForSeconds(RandomWait);

        StartCoroutine("BulletAttack");
    }

    IEnumerator NomalBullet()
    {
        float RandomWait = Random.Range(1f, 3f);
        EnemyAttack[0].SetTrigger("Attack");
        Instantiate(Bullet,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(RandomWait);
        StartCoroutine("NomalBullet");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Attack = 0f;
    [SerializeField] float Attack2 = 0f;
    [SerializeField] GameObject[] PlayerStacks;

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletB;
    [SerializeField] Animator animator; //New
    [SerializeField] GameObject respawn;

    [SerializeField] Vector3 BulletPos;
    public bool EnemySound = false;
    int PlayerStack = 3;
    string gameover = "GameOver";
    public AudioClip BulletSE;
    public AudioClip Destory;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        BulletPos = transform.Find("BulletGenerator").localPosition;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack += Time.deltaTime;
        Attack2 += Time.deltaTime;

        

        Attack = Mathf.Clamp(Attack, 0f, 0.5f);
        Attack2 = Mathf.Clamp(Attack2, 0f, 3.0f);

        float yMove = Input.GetAxisRaw("Vertical");
        float xMove = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //New
            transform.position = new Vector2(
                Mathf.Clamp(transform.position.x + xMove * 0.06f, -8.25f, 8.6f),
                Mathf.Clamp(transform.position.y + yMove * 0.06f, -4.5f, 4.5f)
                );
        }
        else
        {
            transform.position = new Vector2(
                Mathf.Clamp(transform.position.x + xMove * 0.12f, -8.25f, 8.6f),
                Mathf.Clamp(transform.position.y + yMove * 0.12f, -4.5f, 4.5f)
                );
            //‚±‚±‚Ü‚Å
        }

        

        if (Input.GetMouseButton(0) && Attack == 0.5f)
        {
            Instantiate(Bullet, transform.position + BulletPos, Quaternion.identity);
            Attack = 0f;
            animator.SetTrigger("ShotAnimation"); //New
            audioSource.PlayOneShot(BulletSE);
        }
        if (Input.GetMouseButton(1) && Attack2 == 3.0f)
        {
            Instantiate(BulletB, transform.position + BulletPos, Quaternion.identity);
            Attack2 = 0f;
            animator.SetTrigger("ExShotAnimation"); //New
            audioSource.PlayOneShot(BulletSE);
        }
        if (EnemySound)
        {
            audioSource.PlayOneShot(Destory);
            EnemySound = false;
            Debug.Log(EnemySound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Boss")
        {
            
            gameObject.SetActive(false);

            switch (PlayerStack)
            {
                case 3:
                    PlayerStack--;
                    gameObject.SetActive(true);
                    respawn.SetActive(true);
                    PlayerStacks[2].SetActive(false);
                    audioSource.PlayOneShot(Destory);
                    Invoke("respawnEvent", 5.0f);
                    break;
                case 2:
                    PlayerStack--;
                    gameObject.SetActive(true);
                    respawn.SetActive(true);
                    PlayerStacks[1].SetActive(false);
                    audioSource.PlayOneShot(Destory);
                    Invoke("respawnEvent", 5.0f);
                    break;
                case 1:
                    PlayerStack--;
                    gameObject.SetActive(true);
                    respawn.SetActive(true);
                    PlayerStacks[0].SetActive(false);
                    audioSource.PlayOneShot(Destory);
                    Invoke("respawnEvent", 5.0f);
                    break;
                case 0:
                    SceneManager.LoadScene(gameover);
                    break;
            }

        }
    }

    void respawnEvent()
    {
        respawn.SetActive(false);
    }
}

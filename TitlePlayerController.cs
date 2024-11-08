using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayerController : MonoBehaviour
{
    [SerializeField] Vector3 BulletPos;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletB;
    [SerializeField] Animator animator; //New
    [SerializeField] float Attack = 0f;
    [SerializeField] float Attack2 = 0f;
    AudioSource audioSource;
    public AudioClip Shot;

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
            transform.Translate(xMove * 0.06f, yMove * 0.06f, 0f);
        }
        else
        {
            transform.Translate(xMove * 0.12f, yMove * 0.12f, 0f);
        }

        if (Input.GetMouseButton(0) && Attack == 0.5f)
        {
            Instantiate(Bullet, transform.position + BulletPos, Quaternion.identity);
            Attack = 0f;
            animator.SetTrigger("ShotAnimation"); //New
            audioSource.PlayOneShot(Shot);
        }
        if (Input.GetMouseButton(1) && Attack2 == 3.0f)
        {
            Instantiate(BulletB, transform.position + BulletPos, Quaternion.identity);
            Attack2 = 0f;
            animator.SetTrigger("ExShotAnimation"); //New
            audioSource.PlayOneShot(Shot);
        }
    }
}

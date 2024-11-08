using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerB : MonoBehaviour
{
    [SerializeField] GameObject ExplotionObj;

    Vector3 ExplotionPos;
    public AudioClip Expolion;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0.15f, 0f, 0f);

        if (transform.position.x > 15.0f)
        {
            Destroy(gameObject);
        }

        Invoke("Explosion", 1.3f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Explosion();
            Debug.Log("Damage");
        }
    }
    void Explosion()
    {
        audioSource.PlayOneShot(Expolion);
        Debug.Log("ex");
        ExplotionPos = this.transform.position;
        Instantiate(ExplotionObj, ExplotionPos, Quaternion.identity);
        Destroy(gameObject);
    }

}

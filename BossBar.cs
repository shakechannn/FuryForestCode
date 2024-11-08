using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject Boss;
    [SerializeField] public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1000;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HPSpawn()
    {
        obj.SetActive(true);
    }
}

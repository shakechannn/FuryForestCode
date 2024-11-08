using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] static public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }

    public void AddScore()
    {
        score += 1000;
    }
    public void AddBossScore()
    {
        score += 10000;
    }
}

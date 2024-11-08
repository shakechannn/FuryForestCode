using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = ScoreController.score.ToString();
    }
}

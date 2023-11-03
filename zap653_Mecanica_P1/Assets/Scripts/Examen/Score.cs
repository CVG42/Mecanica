using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int _score;
    public TextMeshProUGUI scoreDisplay;
    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        scoreDisplay.text = _score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _score++;
        }
        
    }
}

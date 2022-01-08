using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private int _score;
    private void Start()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
        _score = 0;
        _scoreText.text = "Score : " + _score;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        Debug.Log(_score);
        _scoreText.text = "Score : " + _score;
    }
}

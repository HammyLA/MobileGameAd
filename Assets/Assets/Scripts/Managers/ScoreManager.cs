using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    private void Update()
    {
        score = GameManager.Instance.GetAmountDefeated();
    }

    public void SubmitScore()
    {
        if (inputName.text != null)
        {
            submitScoreEvent.Invoke(inputName.text, score);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        if (inputName.text != null)
        {
            submitScoreEvent.Invoke(inputName.text, GameManager.Instance.GetAmountDefeated());
        }
    }
}

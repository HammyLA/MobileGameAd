using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyCountText;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        Hide();

        restartButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.SampleScene);
        });

        GameEndManager.instance.OnGameEnd += GameEndManager_OnGameEnd;
    }

    private void GameEndManager_OnGameEnd(object sender, System.EventArgs e)
    {
        GameInput.instance.DisablePlayerInputs();
        enemyCountText.text = GameManager.Instance.GetAmountDefeated().ToString();
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false); 
    }
}

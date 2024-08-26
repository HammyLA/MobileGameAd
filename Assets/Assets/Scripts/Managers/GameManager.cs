using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnCoinChange;

    private int amountDefeated;
    [SerializeField] private int coinAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        amountDefeated = 0;

        Enemy.onKill += Enemy_onKill;
    }

    private void OnDestroy()
    {
        Enemy.onKill -= Enemy_onKill;
    }

    private void Enemy_onKill(object sender, System.EventArgs e)
    {
        int coinChance = UnityEngine.Random.Range(1, 100);

        if (coinChance >= 70)
        {
            coinAmount++;
            OnCoinChange?.Invoke(this, EventArgs.Empty);
        }
    }

    public int GetAmountDefeated()
    {
        return amountDefeated;
    }

    public int GetCoinAmount()
    {
        return coinAmount;
    }

    public void SetCoinAmount(int newCoinAmount)
    {
        coinAmount = newCoinAmount;
        OnCoinChange?.Invoke(this, EventArgs.Empty);
    }

    public void IncrementAmountDefeated()
    {
        amountDefeated++;
    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}

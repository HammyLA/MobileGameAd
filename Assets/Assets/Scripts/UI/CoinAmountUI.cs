using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAmountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinAmountText;

    private int coinAmount;

    private void Start()
    {
        coinAmount = 0;
        SetCoinText();

        GameManager.Instance.OnCoinChange += GameManager_OnCoinChange;
    }

    private void GameManager_OnCoinChange(object sender, System.EventArgs e)
    {
        SetCoinAmount();
        SetCoinText();
    }

    private void SetCoinText()
    {
        coinAmountText.text = "Coins: " + coinAmount.ToString();
    }

    private void SetCoinAmount()
    {
        coinAmount = GameManager.Instance.GetCoinAmount();
    }
}

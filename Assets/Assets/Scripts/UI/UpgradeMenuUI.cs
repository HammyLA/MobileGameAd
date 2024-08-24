using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button upgradePlayerButton;
    [SerializeField] private Button upgradeWeaponButton;
    [SerializeField] private Transform playerUpgradeBar;
    [SerializeField] private Transform weaponUpgradeBar;
    [SerializeField] private Image upgradeIcon;
    [SerializeField] private TextMeshProUGUI upgradePlayerCost;
    [SerializeField] private TextMeshProUGUI upgradeGunCostText;

    private bool playerIsMaxed;
    private bool weaponIsMaxed;
    private bool isPaused;
    private void Start()
    {
        int maxUpgrade = 8;
        weaponIsMaxed = false;
        playerIsMaxed = false;


        closeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.PauseGame(isPaused);
            isPaused = false;
            Hide();
        });

        upgradePlayerButton.onClick.AddListener(() =>
        {
            if (UpgradeManager.instance.UpgradePlayer() && playerUpgradeBar.GetComponentsInChildren<Image>().Length < maxUpgrade)
            {
                Instantiate(upgradeIcon, playerUpgradeBar);
                Debug.Log(playerUpgradeBar.GetComponentsInChildren<Image>().Length.ToString());
                SetPlayerCosts();
            }
            else if (playerUpgradeBar.GetComponentsInChildren<Image>().Length == maxUpgrade)
            {
                Instantiate(upgradeIcon, playerUpgradeBar);
                playerIsMaxed = true;
                SetPlayerCosts();
            }
        });

        upgradeWeaponButton.onClick.AddListener(() =>
        {
            if (UpgradeManager.instance.UpgradeGun() && weaponUpgradeBar.GetComponentsInChildren<Image>().Length < maxUpgrade)
            {
                Instantiate(upgradeIcon, weaponUpgradeBar);
                SetWeaponCosts();
            }
            else if (UpgradeManager.instance.UpgradeGun() && weaponUpgradeBar.GetComponentsInChildren<Image>().Length == maxUpgrade)
            {
                Instantiate(upgradeIcon, weaponUpgradeBar);
                weaponIsMaxed = true;
                SetWeaponCosts();
            }
        });

        isPaused = false;
        SetCosts();
        Hide();

        GameInput.instance.OnMenuPerformed += GameInput_OnMenuPerformed;
    }

    private void GameInput_OnMenuPerformed(object sender, System.EventArgs e)
    {
        GameManager.Instance.PauseGame(isPaused);
        if (isPaused)
        {
            Hide();
            isPaused = false;
        }
        else
        {
            Show();
            isPaused = true;
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void SetCosts()
    {
        SetPlayerCosts();
        SetWeaponCosts();
    }

    private void SetPlayerCosts()
    {
        if (playerIsMaxed)
        {
            upgradePlayerCost.text = "COST: X";
        }
        else
        {
            upgradePlayerCost.text = "COST: " + UpgradeManager.instance.GetPlayerUpgradeCost().ToString();
        }


    }

    private void SetWeaponCosts()
    {
        if (weaponIsMaxed)
        {
            upgradeGunCostText.text = "COST: X";
        }
        else
        {
            upgradeGunCostText.text = "COST: " + UpgradeManager.instance.GetGunUpgradeCost().ToString();
        }
    }

}

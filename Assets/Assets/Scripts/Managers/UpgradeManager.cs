using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance {  get; private set; }


    [SerializeField] private int playerUpgradeCost;
    [SerializeField] private int weaponUpgradeCost;


    private void Awake()
    {
        instance = this;
    }

    public bool UpgradePlayer()
    {
        if (GameManager.Instance.GetCoinAmount() >= playerUpgradeCost && PlayerManager.Instance.GetPlayerPFList().Length < 8)
        {
            GameManager.Instance.SetCoinAmount(GameManager.Instance.GetCoinAmount() - playerUpgradeCost);
            PlayerManager.Instance.AddPlayer();
            playerUpgradeCost += playerUpgradeCost;
            return true;
        }

        return false;
    }

    public bool UpgradeGun()
    {
        if (GameManager.Instance.GetCoinAmount() >= weaponUpgradeCost)
        {
            GameManager.Instance.SetCoinAmount(GameManager.Instance.GetCoinAmount() - weaponUpgradeCost);
            PlayerManager.Instance.upgradePlayerWeapons();
            weaponUpgradeCost += weaponUpgradeCost;
            return true;
        }

        return false;
    }

    public int GetPlayerUpgradeCost()
    {
        return playerUpgradeCost;
    }

    public int GetGunUpgradeCost()
    {
        return weaponUpgradeCost; 
    }

}

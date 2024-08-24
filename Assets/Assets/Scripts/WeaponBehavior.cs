using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{

    public class OnShootEventArgs : EventArgs
    {
        public float damage;
        public Transform shootPosition;
    }

    [SerializeField] private Player player;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform bullet;

    private WeaponSO weaponSO;
    private float weaponFireRateMax;
    private float weaponFireRate;
    private Transform gunTransform;

    private void Start()
    {
        gunTransform = PlayerManager.Instance.GetPlayerWeaponSO().visual.transform;
        weaponSO = PlayerManager.Instance.GetPlayerWeaponSO();

        weaponFireRateMax = 1 / weaponSO.firerate;
        weaponFireRate = weaponFireRateMax;
    }

    private void Update()
    {
        gunTransform.transform.position = player.GetHoldPoint().position;

        weaponFireRate -= Time.deltaTime;      
        if (weaponFireRate <= 0 )
        {
            GetComponentInParent<PlayerAnimator>().TriggerShoot();
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
            weaponFireRate = weaponFireRateMax;
        }
    }

    private void setWeaponSO(WeaponSO weaponSO)
    {
        this.weaponSO = weaponSO;
    }

    private WeaponSO getWeaponSO()
    {
        return weaponSO;
    }
        
}

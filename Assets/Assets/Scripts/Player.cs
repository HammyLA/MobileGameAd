using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private Transform holdPoint;

    private WeaponSO weaponSO;
    private GameInput gameInput;

    private void Start()
    {
        weaponSO = PlayerManager.Instance.GetPlayerWeaponSO();
        gameInput = GameInput.instance;
        Transform gunPos = Instantiate(weaponSO.visual.transform, holdPoint);
        gunPos.localPosition = Vector3.zero;
    }
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }

    public WeaponSO GetPlayerWeaponSO()
    {
        return weaponSO;
    }

    public void SetPlayerWeaponSO(WeaponSO newWeaponSO)
    {
        Destroy(GetComponentInChildren<WeaponBehavior>().gameObject);
        weaponSO = newWeaponSO;
        Transform gunPos = Instantiate(weaponSO.visual.transform, holdPoint);
        gunPos.localPosition = Vector3.zero;
    }
}

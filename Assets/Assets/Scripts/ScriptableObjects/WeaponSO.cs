using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponSO : ScriptableObject 
{
    public float damage;
    public float firerate;
    public GameObject visual;
    public WeaponSO upgradeSO;
}

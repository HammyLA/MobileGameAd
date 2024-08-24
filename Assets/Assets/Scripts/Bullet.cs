using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int ENEMY_LAYER = 7;
    public event EventHandler<OnHitArgs> OnHit;

    [SerializeField] private Transform bullet;
    [SerializeField] private Player player;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float accuracy;

    public class OnHitArgs : EventArgs
    {
        public float damage = bulletDamage;
    }

    private CapsuleCollider hitCapsule;
    private WeaponSO weaponSO;
    private Vector3 moveDir;
    private static float bulletDamage;
    private float moveAngle;

    private void Start()
    {
        weaponSO = PlayerManager.Instance.GetPlayerWeaponSO();
        hitCapsule = GetComponent<CapsuleCollider>();
        bulletDamage = weaponSO.damage;
        float moveAngle = UnityEngine.Random.Range(-accuracy, accuracy);
        moveDir = new Vector3(moveAngle, 0, 1).normalized * bulletSpeed;
    }

    private void Update()
    {
        bullet.position += moveDir * Time.deltaTime;

        if (bullet.position.z >= DeleteBullet.instance.getZPos())
        {
            Destroy(this.gameObject);
        }
    }

    private void setWeaponSO(WeaponSO weaponSO)
    {
        this.weaponSO = weaponSO;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            if (enemyComponent.getHealth() > 0)
            {
                Destroy(this.gameObject);
                enemyComponent.TakeDamage(bulletDamage);
            }
        }
    }
}

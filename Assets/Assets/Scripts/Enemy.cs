using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler onKill;
    public static event EventHandler onReachedEnd;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float enemyMaxHealth;

    private Transform enemyPF;
    private bool isHit;
    private bool isDead;
    private float health;


    private void Start()
    {
        isDead = false;
        enemyPF = GetComponent<Transform>();
        health = enemyMaxHealth;
    }

    private void Update()
    {
        if (!isDead)
        {
            enemyPF.position += (Vector3.back).normalized * moveSpeed * Time.deltaTime;
        }

        
        if (enemyPF.position.z <= GameEndManager.instance.GetEndTransform().position.z)
        {
            Destroy(gameObject);
            if (PlayerManager.Instance.GetPlayerHealth() > 0)
            {
                PlayerManager.Instance.decrementHealth();
                onReachedEnd?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(GetComponent<BoxCollider>());
            isDead = true;
            GetComponentInChildren<EnemyAnimator>().TriggerDeath();
            GameManager.Instance.IncrementAmountDefeated();
            onKill?.Invoke(this, EventArgs.Empty);
            StartCoroutine(WaitToDelete(2));
        }
    }

    private IEnumerator WaitToDelete(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

}

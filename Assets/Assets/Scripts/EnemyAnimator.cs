using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IS_DEAD = "IsDead";

    private Enemy enemy;
    private Animator animator;

    private void Awake()
    {
        enemy = this.GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }

    public void TriggerDeath()
    {
        animator.SetTrigger(IS_DEAD);
    }
}

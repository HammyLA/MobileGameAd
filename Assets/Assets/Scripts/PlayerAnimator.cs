using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_SHOOTING = "IsShooting";
    private const string END_SHOOTING = "EndShooting";

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerShoot()
    {
        animator.SetTrigger(IS_SHOOTING);
    }

    public void EndShoot()
    {
        animator.SetTrigger(END_SHOOTING);
    }
}

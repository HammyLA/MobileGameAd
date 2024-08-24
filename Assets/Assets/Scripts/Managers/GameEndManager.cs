using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameEndManager : MonoBehaviour
{
    public event EventHandler OnGameEnd;
    public static GameEndManager instance {  get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Enemy.onReachedEnd += Enemy_onReachedEnd;
    }

    private void OnDestroy()
    {
        Enemy.onReachedEnd -= Enemy_onReachedEnd;
    }

    private void Enemy_onReachedEnd(object sender, System.EventArgs e)
    {
        if (PlayerManager.Instance.GetPlayerHealth() <= 0)
        {
            OnGameEnd?.Invoke(this, EventArgs.Empty);
        }
    }

    public Transform GetEndTransform()
    {

        return this.transform;
    }
}

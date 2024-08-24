using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Image HealthBarIcon;

    private void Start()
    {
        SetHealthBar();

        Enemy.onReachedEnd += Enemy_onReachedEnd;
    }

    private void OnDestroy()
    {

        Enemy.onReachedEnd -= Enemy_onReachedEnd;
    }

    private void Enemy_onReachedEnd(object sender, System.EventArgs e)
    {
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        foreach (HealthIcon healthIcon in GetComponentsInChildren<HealthIcon>())
        {
            Destroy(healthIcon.gameObject);
        }
        for (int i = 0; i < PlayerManager.Instance.GetPlayerHealth(); i++)
        {
            Instantiate(HealthBarIcon, this.transform);
        }
    }
}

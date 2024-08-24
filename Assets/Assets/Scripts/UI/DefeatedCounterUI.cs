using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefeatedCounterUI : MonoBehaviour
{
    private const string ENEMY_DEFEATED_TEXT = "ENEMIES DEFEATED: ";

    [SerializeField] private TextMeshProUGUI enemyDefeatedText;
    private int enemiesDefeated;

    private void Start()
    {
        Enemy.onKill += Enemy_onKill;
        UpdateVisual();
    }

    private void OnDestroy()
    {
        Enemy.onKill -= Enemy_onKill;
    }

    private void Enemy_onKill(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        enemyDefeatedText.text = ENEMY_DEFEATED_TEXT + GameManager.Instance.GetAmountDefeated(); ;
    }
}

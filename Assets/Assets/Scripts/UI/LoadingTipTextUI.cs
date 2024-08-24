using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingTipTextUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI loadingText;

    private void Start()
    {
        loadingText.text = "TIP: " + LoadingText.getListString().GetValue(Random.Range(0, LoadingText.getListString().Length - 1));
    }

}

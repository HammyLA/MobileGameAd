using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitMenuButtonUI : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    private void Start()
    {
        quitButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MenuScene);
        });
    }
}

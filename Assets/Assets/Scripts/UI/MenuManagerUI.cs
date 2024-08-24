using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagerUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.SampleScene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}

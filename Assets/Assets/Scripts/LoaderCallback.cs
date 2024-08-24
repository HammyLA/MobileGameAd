using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;

            Time.timeScale = 1f;

            StartCoroutine(WaitToLoad(1));
        }
    }

    private IEnumerator WaitToLoad(float seconds)
    {
        Debug.Log("In coroutine");
        yield return new WaitForSeconds(seconds);

        Debug.Log("got passed wait");
        Loader.LoaderCallback();
    }

}

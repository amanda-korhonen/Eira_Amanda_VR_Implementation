using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    private bool isLoadingScene = false;

    // We use async below to help with latency
    public void GoToSceneAsync(int sceneIndex)
    {
        if (isLoadingScene) //makes sure that scene loads only once
        {
            return;
        }

        isLoadingScene = true;
        
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        //Launch the new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        operation.allowSceneActivation = true;
    }
}

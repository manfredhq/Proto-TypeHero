using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField]
    private float minTime = 2f;

    private void Start()
    {
        StartCoroutine(LoadPlaySceneCoroutine());
    }

    private IEnumerator LoadPlaySceneCoroutine()
    {
        yield return new WaitForSecondsRealtime(minTime);
        SceneManager.LoadSceneAsync(1);
    }
}

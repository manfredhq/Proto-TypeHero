using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource aSource;

    [SerializeField]
    private AudioClipInfo defaultBackgroundMusic;
    [SerializeField]
    private AudioClipInfo fightBackgroundMusic;

    private void Start()
    {
        aSource.clip = defaultBackgroundMusic.clip;
        aSource.volume = defaultBackgroundMusic.targetVolume;
        aSource.Play();
    }
    public void OnFightStart()
    {
        StartCoroutine(TransitionMusics(aSource, fightBackgroundMusic));
    }

    public void OnFightEnd()
    {

        StartCoroutine(TransitionMusics(aSource, defaultBackgroundMusic));
    }

    private IEnumerator TransitionMusics(AudioSource source, AudioClipInfo targetSound)
    {
        Coroutine currentCoroutine = StartCoroutine(FadeOutCurrentMusic());
        yield return new WaitUntil(() => aSource.volume == 0);
        StopCoroutine(currentCoroutine);
        source.clip = targetSound.clip;
        source.Play();
        currentCoroutine = StartCoroutine(FadeInNewMusic(targetSound.targetVolume));
        yield return new WaitUntil(() => aSource.volume == targetSound.targetVolume);
        StopCoroutine(currentCoroutine);
    }

    private IEnumerator FadeOutCurrentMusic()
    {
        while(aSource.volume >= 0)
        {
            aSource.volume -= Time.deltaTime;
            if (aSource.volume < Time.deltaTime) aSource.volume = 0;
            yield return null;
        }
    }

    private IEnumerator FadeInNewMusic(float targetVolume)
    {
        while (aSource.volume < targetVolume)
        {
            aSource.volume += Time.deltaTime;
            if (aSource.volume > targetVolume) aSource.volume = targetVolume;
            Debug.Log($"{aSource.volume} < {targetVolume}");
            yield return null;
        }
    }

    
}
[System.Serializable]
public struct AudioClipInfo
{
    public AudioClip clip;
    [Range(0, 1)]
    public float targetVolume;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioParams> aParams = new List<AudioParams>();


    private void Update()
    {
        List<AudioParams> aParamsToRemove = new List<AudioParams>();
        foreach (var aParam in aParams)
        {
            if(Time.time >= aParam.timeToDestroy)
            {
                aParam.aSource.Stop();
                Destroy(aParam.aSource);
                aParamsToRemove.Add(aParam);
            }
        }
        foreach (var a in aParamsToRemove)
        {
            aParams.Remove(a);
        }
        aParamsToRemove.Clear();
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        AudioParams aParam = aParams.Find((ap) => { return ap.aClip == clip; });

        if (aParam.aSource == null)
        { 
            AudioParams newParam = new AudioParams();
            newParam.aSource = gameObject.AddComponent<AudioSource>();
            newParam.aClip = clip;
            newParam.timeToDestroy = Time.time + clip.length;
            newParam.aSource.clip = newParam.aClip;
            newParam.aSource.volume = volume;
            newParam.aSource.Play();
            aParams.Add(newParam);
        }
    }
}

[System.Serializable]
public struct AudioParams
{
    public AudioClip aClip;
    public AudioSource aSource;
    public float timeToDestroy;
}

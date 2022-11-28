using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private float startVolume;
    public int fadeFrameCount = 180;

    private IEnumerable Start()
    {
        audioSource= GetComponent<AudioSource>();
        startVolume = audioSource.volume;

        int i = 0;
        while (i < fadeFrameCount)
        {
            i++;
            audioSource.volume = Mathf.Lerp(0, startVolume, i / (float)fadeFrameCount);
            yield return null;
        }
    }
}

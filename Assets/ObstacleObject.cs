using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public SoundType type;
    public AudioClip[] bouteille;
    public AudioClip[] bois;
    public AudioClip[] planche;
    public AudioClip[] pneu;
    public AudioClip[] tuyau;
    public AudioClip[] voiture;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case SoundType.bouteille:
                audioSource.clip = bouteille[Random.Range(0, bouteille.Length)];
                break;
            case SoundType.bois:
                audioSource.clip = bois[Random.Range(0, bois.Length)];
                break;
            case SoundType.planche:
                audioSource.clip = planche[Random.Range(0, planche.Length)];
                break;
            case SoundType.pneu:
                audioSource.clip = pneu[Random.Range(0, pneu.Length)];
                break;
            case SoundType.tuyau:
                audioSource.clip = tuyau[Random.Range(0, tuyau.Length)];
                break;
            case SoundType.voiture:
                audioSource.clip = voiture[Random.Range(0, voiture.Length)];
                break;
            default:
                break;
        }

        audioSource.Play();
    }

    public enum SoundType
    {
        bouteille,
        bois,
        planche,
        pneu,
        tuyau,
        voiture
    }
}

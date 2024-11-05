using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sounds 
{
    public static AudioClip backGround;
    public static AudioClip openCell;
    public static AudioClip flagCell;
    public static AudioClip boomSound;
    public static AudioSource audioSource;
    public static float volume = 1f;

    public static void PlayBackGroundSound()
    {
        audioSource.PlayOneShot(backGround, volume);
    }
    public static void PlayOpenCell()
    {
        audioSource.PlayOneShot(openCell, volume);
    }
    public static void PlayFlagCell()
    {
        audioSource.PlayOneShot(flagCell, volume);
    }
    public static void PlayBoom()
    {
        audioSource.PlayOneShot(boomSound, volume);
    }
}

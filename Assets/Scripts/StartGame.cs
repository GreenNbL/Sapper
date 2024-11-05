using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private AudioClip backGround;
    [SerializeField] private AudioClip openCell;
    [SerializeField] private AudioClip flagCell;
    [SerializeField] private AudioClip boomSound;
    private AudioSource audioSrc => GetComponent<AudioSource>();  
    void Start()
    {
        Sounds.audioSource = audioSrc;
        Sounds.backGround = backGround;
        Sounds.flagCell = flagCell;
        Sounds.openCell = openCell;
        Sounds.boomSound = boomSound;
        Sounds.PlayBackGroundSound();
    }

    
}

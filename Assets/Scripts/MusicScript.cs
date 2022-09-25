using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioClip playIntro;
    public AudioClip playNormal;
    public AudioSource audioPlayer;

    void Start()
    {
      audioPlayer.clip = playIntro;
      audioPlayer.Play();
    }

    void Update()
    {
      if (audioPlayer.isPlaying == false && audioPlayer.clip == playNormal){
        audioPlayer.Play();
      }
      else if (audioPlayer.isPlaying == false && audioPlayer.clip == playIntro){
        audioPlayer.clip=playNormal;
      }
    }
}

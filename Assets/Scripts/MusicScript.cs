using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
  /*
------------> I am well aware that this code is horrendous. I think it's terrible
but it works! i think!
    */
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

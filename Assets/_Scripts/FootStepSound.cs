using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
  [SerializeField] private AudioClip footsoundclip;
  private AudioSource soundSource;


  private void Start()
  {
    soundSource = GetComponentInChildren<AudioSource>();
  }

  public void PlayerFootStepSound()
  {
    Debug.Log("play");
    soundSource.PlayOneShot(footsoundclip);
  }
}

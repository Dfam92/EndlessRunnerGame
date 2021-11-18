using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip rollClip;
    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip clipButton;
    [SerializeField] private AudioClip countDownEnd;
    private AudioSource audioSource;

    private AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;

    public void PlayJumpClip()
    {
        Play(jumpClip);
    }

    public void PlayRollClip()
    {
        Play(rollClip);
    }

    public void PlayDieClip()
    {
        Play(dieClip);
    }

    public void PlayClipButton()
    {
        Play(clipButton);
    }

    public void PlayFinalCountdDown()
    {
        Play(countDownEnd);
    }
    private void Play(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.loop = false;
        AudioSource.Play();
    }
}

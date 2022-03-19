using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundClipSource;
    [SerializeField] private AudioSource BkgSoundClipSource;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip newHighScoreClip;
    [SerializeField] private AudioClip normalEndClip;
    
    [HideInInspector] public bool _soundPlayed = false;

    public void PlayHit()
    {
        soundClipSource.PlayOneShot(hitClip);
    }

   

    public void PlayHighScore()
    {
        soundClipSource.PlayOneShot(newHighScoreClip);
    }

    public void PlayEnd()
    {
        soundClipSource.PlayOneShot(normalEndClip);
    }

    public bool SoundPlaying()
    {
        return false;
    }

    /// <summary>
    /// Coroutine to wait for previous sound to finish
    /// before playing end sound
    /// </summary>
    /// <param name="didWin"> If we won or lost</param>
    /// <param name="soundOn">state of the mute control</param>
    /// <returns></returns>
    public IEnumerator PlayEndSounds(bool didWin, bool soundOn)
    {
        while (soundClipSource.isPlaying)
        {
            yield return null;
        }
        if (!_soundPlayed && soundOn)
        {
            if (didWin) soundClipSource.PlayOneShot(newHighScoreClip);
            else soundClipSource.PlayOneShot(normalEndClip);
        }
        _soundPlayed = true;
    }

    public void BkgSound(string soundState)
    {
        switch (soundState)
        {
            case "play":
                BkgSoundClipSource.Play();
                break;
            case "pause":
                BkgSoundClipSource.Pause();
                break;
            case "resume":
                BkgSoundClipSource.UnPause();
                break;
            case "stop":
                BkgSoundClipSource.Stop();
                break;
        }
    }
}

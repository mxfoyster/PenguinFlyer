using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //our audio handles
    [SerializeField] private AudioSource soundClipSource;
    [SerializeField] private AudioSource BkgSoundClipSource;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip newHighScoreClip;
    [SerializeField] private AudioClip normalEndClip;
    
    [HideInInspector] public bool _soundPlayed = false; //coroutine flag
    [HideInInspector] public bool unmuteSound; //mute status

    public void PlayHit()
    {
        if (unmuteSound) soundClipSource.PlayOneShot(hitClip);
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

    /// <summary>
    /// Control the state of our background sound.
    /// Checks unmuteSound status.
    /// </summary>
    /// <param name="soundState">"play", "pause", "resume" and "stop".</param>
    public void BkgSound(string soundState)
    {
        if (unmuteSound)
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


    /// <summary>
    /// Toggles between muted and unmuted
    /// </summary>
    public void ToggleAudio()
    {
        if (unmuteSound)
        {
            BkgSoundClipSource.Pause();
            unmuteSound = false;
        }
        else
        {
            BkgSoundClipSource.UnPause();
            unmuteSound = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10)) ToggleAudio(); //mute toggle key
    }
}

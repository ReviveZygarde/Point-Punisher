using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource shootSoundEffect;
    public AudioSource lowHPsoundLoop;
    public AudioSource getStar;
    public AudioSource errorSound;

    public void shootSoundPlayback()
    {
        shootSoundEffect.Play();
    }

    public void lowHPalarmPlayback()
    {
        if (lowHPsoundLoop.isPlaying == false)
        {
            lowHPsoundLoop.Play();
        }
    }

    public void lowHPalarmStop()
    {
        if (lowHPsoundLoop.isPlaying)
        {
            lowHPsoundLoop.Stop();
        }
    }

    public void starSoundEffect()
    {
        getStar.Play();
    }

    public void errorPlay()
    {
        errorSound.Play();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapShot;

    public float transitionTime = 0.1f;

    public void MakeTransition()
    {
        snapShot.TransitionTo(transitionTime);
    }
}

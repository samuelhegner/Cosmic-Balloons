using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {


	Sound() {

		volume = 1f;
		pitch = 1f;
		

	}

	public string name;

	public AudioMixerGroup audioMixerGroup;

	public AudioClip[] clips;

	[Range(0f, 1f)]  public float volume = 1f;
	[Range(.1f, 3f)] public float pitch = 1f;
	[Range(0f, 1f)] public float spatialBlend;

	public bool loop;
	public bool mute;
	public bool playOnAwake; 


	[HideInInspector] public AudioSource source;
	[HideInInspector]
	public bool FadingIn, FadingOut;
	


	public AudioClip GetClip() {

		if (clips.Length > 0) {

			int choice = Random.Range(0, clips.Length);

			return clips[choice];

		} else {

			return null;

		}
	}


}

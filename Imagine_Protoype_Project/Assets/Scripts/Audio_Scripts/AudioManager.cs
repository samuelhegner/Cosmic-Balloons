using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

	public Sound[] sounds = new Sound[1];

	public bool master;
	public bool DontDestroyOnLoad;
	
	[HideInInspector]
	public static AudioManager Master;

	void Start() {

		
		
	}

	void Awake() {


		if (master){

			if (Master == null) {

				Master = this;

			} else {

				DestroyImmediate(gameObject);
				return;

			}

			if (DontDestroyOnLoad) {
				
				DontDestroyOnLoad(gameObject);
				
			}
		}

	foreach (Sound s in sounds) {
			s.source                       = gameObject.AddComponent<AudioSource>();
		
			s.source.outputAudioMixerGroup = s.audioMixerGroup;

			s.source.volume = s.volume;
			s.source.pitch  = s.pitch;
			s.source.loop   = s.loop;
			s.source.mute = s.mute;
			s.source.playOnAwake = s.playOnAwake;

		if (s.playOnAwake) {

			Play(s.name);
			
		}

	}
	}
	
	
	
	public void Play(string name, bool Fade = false, float FadeTime = 1f, float defaultVolume = 1f) {

		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.clip = s.GetClip();

		if (s.source.isPlaying) {

		} else {

			s.source.Play();
		}

		if (Fade) {


			StartCoroutine(FadeIn(s, FadeTime, defaultVolume));

		}


	}

	public void PlayImmediately(string name) {

		Play(name);
		
	}

	public void StopImmediately(string name) {

		Stop(name);
		
	}


	IEnumerator FadeIn(Sound s, float fadeTime, float defaultVolume) {

		

		s.FadingOut = false;
		s.FadingIn = true;

		s.source.volume = 0f;

		while (s.source.volume < defaultVolume && s.FadingIn) {
			s.source.volume += ((1 / fadeTime) * Time.fixedDeltaTime);
			yield return null;
		}

	//	s.source.volume = defaultVolume;
//		s.FadingIn = false;



	}


	public void Stop(string name, bool Fade = false, float fadeTime = 1f) {

		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;

		}

		
			if (s.source.isPlaying) {
				if (!Fade) {
					s.source.Stop();

					Debug.Log("Stopped: " + name);
				} else {

					//TODO fade audio Scriping (IENumerator)

					StartCoroutine(FadeOut(s, fadeTime));

				}



			} else {

				Debug.LogWarning("Sound: " + name + " is not playing");
				return;

			}
		


	}


	IEnumerator FadeOut(Sound s, float fadeTime) {

		s.FadingOut = true;
			s.FadingIn = false;

		//	float defaultVolume = source.volume;

		while (s.source.volume > 0 && s.FadingOut) {
			s.source.volume -= ((1 / fadeTime) * Time.fixedDeltaTime);
			yield return null;

		}

//		s.source.volume = defaultVolume;
	//	s.source.Stop();
		//s.FadingOut = false;

	}

	
	
	
	
	
	
	public void Pause(string name) {

		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;

		}

		if (s.source.isPlaying) {

			s.source.Pause();
			Debug.Log("Paused: " + name);

		} else {

			Debug.LogWarning("Sound: " + name + " is not playing");
			return;

		}
		
		
		
		
	}


	public void ChangePitch(string name, float newLevel, float max) {

		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;

		}

		
		s.source.pitch = newLevel;

		if (s.source.pitch > max) {

			s.source.pitch = max;

		}



	}


	public soundInfo GetSoundData(string name) {

		Sound s = Array.Find(sounds, sound => sound.name == name);
		
		soundInfo SI = new soundInfo();

		SI.length = s.source.clip.length;
		SI.currentTime = s.source.time;

		return SI;

	}




}

public struct soundInfo {

	public float length;
	public float currentTime;


}

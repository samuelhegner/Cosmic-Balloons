using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class Audio_Settings_Manager : MonoBehaviour {

	public Slider JourneyVolumeSlider;
	public Slider SfxVolumeSlider;
	public Slider MusicVolumeSlider;


	private const string SettingsSaveFile = "Cosmic_Balloons_Settings.txt";

	public static Settings CurrrentSettings;
	
	

	private string settingsFullPath;
	
	// Use this for initialization
	void Start () {

		
		CurrrentSettings = new Settings();
		
		settingsFullPath = Application.persistentDataPath + "/" + SettingsSaveFile;

		if (!System.IO.File.Exists(settingsFullPath)) {


			System.IO.File.CreateText(settingsFullPath).Dispose();

			WriteSettings();

		} 
		
		ReadSettings();
		WriteSettings();

		JourneyVolumeSlider.value = CurrrentSettings.JourneyVolume;
		SfxVolumeSlider.value = CurrrentSettings.SfxVolume;
		MusicVolumeSlider.value = CurrrentSettings.MusicVolume;


	}



	public void WriteSettings() {

		Debug.Log("Writing: " + settingsFullPath);
		
		var jsonOut = JsonUtility.ToJson(CurrrentSettings);

		Debug.Log(jsonOut);
		
		System.IO.File.WriteAllText(settingsFullPath, jsonOut);

		Debug.Log("Write successful");

	}

public	void ReadSettings() {


		Debug.Log("Reading: " + settingsFullPath);
		
		var jsonIn = System.IO.File.ReadAllText(settingsFullPath);
		
		Debug.Log(jsonIn);
		
		CurrrentSettings = JsonUtility.FromJson<Settings>(jsonIn);

Debug.Log("Read successful");



	}

	// Update is called once per frame
	void Update () {


	

	}
}

[System.Serializable]
public class Settings {

	
	public float JourneyVolume = new float(); //0f;


	public float SfxVolume = new float();

	
	public float MusicVolume = new float();


}



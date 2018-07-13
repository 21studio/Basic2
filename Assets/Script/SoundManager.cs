using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFX {
	BOMB = 0,
	DAMAGE
}

public class SoundManager : MonoBehaviour {

	public static SoundManager instance { get; private set; }

	public AudioClip music;
	public AudioSource audioSource;

	public AudioClip[] sfxClips;

	public void PlaySFX(SFX sfx) {
		AudioClip clip = sfxClips[(int)sfx];
		audioSource.PlayOneShot(clip);
	}
	
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		
		audioSource = GetComponent<AudioSource>();
		if (music != null) {
			audioSource.clip = music;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

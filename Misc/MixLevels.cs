using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MixLevels : MonoBehaviour {

    public AudioMixer BackgroundMusic;
    public AudioMixer Sfx;

	public void SetSfxLvl(float sfxlvl) {
        Sfx.SetFloat("SfxLvl", sfxlvl);
    }
	
	public void SetMusicLvl(float musiclvl) {
        BackgroundMusic.SetFloat("MusicLvl", musiclvl);
    }
}

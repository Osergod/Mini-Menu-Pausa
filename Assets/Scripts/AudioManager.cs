using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Inicializa volúmenes
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;

        // Empieza la música
        musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void PlaySFX()
    {
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}

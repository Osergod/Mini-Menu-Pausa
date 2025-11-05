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
        // Inicializa volúmenes con los valores actuales de los sliders
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;

        // Configura los eventos de los sliders para cambiar el volumen en tiempo real
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Empieza la música
        musicSource.Play();
    }

    // Función para cambiar el volumen de la música
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Función para cambiar el volumen de los efectos de sonido
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    // Función para reproducir un SFX cuando se hace clic
    public void PlaySFX()
    {
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}

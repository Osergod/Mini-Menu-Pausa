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
        // Cargar los valores guardados desde PlayerPrefs, si existen
        float musicVol = PlayerPrefs.GetFloat("MusicVol", 0.5f);  // Valor por defecto 0.5 si no existe
        float sfxVol = PlayerPrefs.GetFloat("SFXVol", 0.5f);      // Valor por defecto 0.5 si no existe

        // Asignar los valores cargados a los sliders y a los audio sources
        musicSlider.value = musicVol;
        sfxSlider.value = sfxVol;
        musicSource.volume = musicVol;
        sfxSource.volume = sfxVol;

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
        // Guardar el volumen en PlayerPrefs
        PlayerPrefs.SetFloat("MusicVol", volume);
    }

    // Función para cambiar el volumen de los efectos de sonido
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        // Guardar el volumen en PlayerPrefs
        PlayerPrefs.SetFloat("SFXVol", volume);
    }

    // Función para reproducir un SFX cuando se hace clic
    public void PlaySFX()
    {
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}

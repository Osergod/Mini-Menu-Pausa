using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public Slider musicSlider;
    public Slider sfxSlider;

    public TMP_Dropdown resolutionDropdown;  // TMP Dropdown

    public Toggle fullscreenToggle;  // Referencia al Toggle de Pantalla Completa

    void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVol", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVol", 0.5f);

        musicSlider.value = musicVol;
        sfxSlider.value = sfxVol;
        musicSource.volume = musicVol;
        sfxSource.volume = sfxVol;

        int savedResolution = PlayerPrefs.GetInt("Resolution", 0);

        if (resolutionDropdown != null && resolutionDropdown.options.Count > 0)
        {
            savedResolution = Mathf.Clamp(savedResolution, 0, resolutionDropdown.options.Count - 1);
            resolutionDropdown.value = savedResolution;
            resolutionDropdown.RefreshShownValue();
            ApplyResolutionByIndex(savedResolution);
            resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        }
        else
        {
            Debug.LogWarning("ResolutionDropdown (TMP) no tiene opciones o no está asignado.");
        }

        // Configurar el evento del Toggle para cambiar entre pantalla completa y ventana
        fullscreenToggle.isOn = Screen.fullScreen;
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggleChanged);


        if (!musicSource.isPlaying)
            musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVol", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVol", volume);
    }

    public void PlaySFX()
    {
        if (sfxSource.clip != null)
            sfxSource.PlayOneShot(sfxSource.clip);
    }

    public void OnResolutionChanged(int index)
    {
        ApplyResolutionByIndex(index);
        PlayerPrefs.SetInt("Resolution", index);
    }

    private void ApplyResolutionByIndex(int index)
    {
        switch (index)
        {
            case 0: SetResolution(1920, 1080); break;
            case 1: SetResolution(1280, 720); break;
            case 2: SetResolution(1024, 768); break;
            default:
                SetResolution(1920, 1080); break;
        }
    }

    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void RestartValuesVolume()
    {
        PlayerPrefs.DeleteKey("MusicVol");
        PlayerPrefs.DeleteKey("SFXVol");

        musicSlider.value = 0.5f;
        sfxSlider.value = 0.5f;

        musicSource.volume = 0.5f;
        sfxSource.volume = 0.5f;

        PlayerPrefs.SetFloat("MusicVol", 0.5f);
        PlayerPrefs.SetFloat("SFXVol", 0.5f);
    }

    public void OnFullscreenToggleChanged(bool isFullscreen)
    {
        // Cambiar el modo de pantalla según el estado del Toggle
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);  // Guardar el estado en PlayerPrefs
    }

}

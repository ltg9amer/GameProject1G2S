using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private List<AudioClip> bgms;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private Slider bgmSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BGM", 1f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGM", 1f);
        SceneManager.sceneLoaded += ClipChange;

        ClipChange(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    public void VolumeChange()
    {
        bgmSource.volume = bgmSlider.value;

        PlayerPrefs.SetFloat("BGM", bgmSlider.value);
    }

    private void ClipChange(Scene currentScene, LoadSceneMode loadSceneMode)
    {
        if (bgmSource.clip)
        {
            bgmSource.Stop();
        }

        if (currentScene.name == "StartScene")
        {
            bgmSource.clip = bgms[0];
            bgmSlider = GameObject.Find("Canvas").transform.GetChild(6).GetChild(3).GetComponent<Slider>();
        }
        else if (currentScene.name == "PlayScene")
        {
            bgmSource.clip = bgms[1];
        }
        else if (currentScene.name == "GameClearScene")
        {
            bgmSource.clip = bgms[2];
        }
        else if (currentScene.name == "GameOverScene")
        {
            bgmSource.clip = bgms[3];
        }

        bgmSource.Play();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicBtnSprite;

    private AudioSource clickSound;


	void Start ()
    {
        if (GameManager.singleton.isMusicOn)
        {
            AudioListener.volume = 1;
            musicBtn.image.sprite = musicBtnSprite[1];
        }
        else
        {
            AudioListener.volume = 0;
            musicBtn.image.sprite = musicBtnSprite[0];
        }
        clickSound = GetComponent<AudioSource>();
	}
	

    public void PlayButton()
    {
        SceneManager.LoadScene("ModeSelector");
        clickSound.Play();
    }


    public void QuitButton()
    {
        Application.Quit();
        //sound mli katwarek 3la button
        clickSound.Play();
    }

    public void MusicButton()
    {
        clickSound.Play();

        if (GameManager.singleton.isMusicOn)
        {
            AudioListener.volume = 0;
            musicBtn.image.sprite = musicBtnSprite[0];
            GameManager.singleton.isMusicOn = false;
            GameManager.singleton.Save();
        }
        else
        {
            AudioListener.volume = 1;
            musicBtn.image.sprite = musicBtnSprite[1];
            GameManager.singleton.isMusicOn = true;
            GameManager.singleton.Save();
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : Singleton<HomeController>
{
    private bool isSound;
    public GameObject btnSoundOn, btnSoundOff;
    private void Start()
    {
        if (Data.MusicState == true)
        {
            btnSoundOff.SetActive(false);
            btnSoundOn.SetActive(true);
            isSound = true;
            SoundController.Instance.PlayBackground(SoundType.BackgroundMusic);
        }
        else
        {
            btnSoundOff.SetActive(true);
            btnSoundOn.SetActive(false);
            isSound = false;
            SoundController.Instance.PauseBackground();
        }
    }
    public void OnClickStartButton()
    {
        SceneController.Instance.LoadGameScene();
    }

    public void OnClickSoundOnButton()
    {
        if (isSound)
        {
            Data.SetBool(Constant.MUSIC_STATE, false);
            btnSoundOn.SetActive(false);
            SoundController.Instance.PauseBackground();
            isSound = false;
            btnSoundOff.SetActive(true);
        }
    }
    public void OnClickSoundOffButton()
    {
        if (!isSound)
        {
            Data.SetBool(Constant.MUSIC_STATE, true);
            btnSoundOff.SetActive(false);
            isSound = true;
            SoundController.Instance.PlayBackground(SoundType.BackgroundMusic);
            btnSoundOn.SetActive(true);
        }
    }
}

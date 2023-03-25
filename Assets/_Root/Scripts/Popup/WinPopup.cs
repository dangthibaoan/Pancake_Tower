using UnityEngine;
using TMPro;

public class WinPopup : Popup
{
    public Level1 lv1;
    public TextMeshProUGUI NewScore;
    public TextMeshProUGUI BestScore;
    public GameObject img;
    public void OnClickHomeButton()
    {
        // Data.SetInt(Constant.MAX_SCORE, 0);
        PopupController.Instance.HideAll();
        SceneController.Instance.LoadHomeScene();
    }

    public void OnClickRetryButton()
    {
        PopupController.Instance.HideAll();
        SceneController.Instance.LoadGameScene();
    }

    public void SetTotalScore(int score)
    {
        if (score >= Data.MaxScore)
        {
            SoundController.Instance.PlayOnce(SoundType.Win);
            img.SetActive(true);
        }
        else
        {
            SoundController.Instance.PlayOnce(SoundType.Lose);
            img.SetActive(false);
        }
        NewScore.SetText(score + "");
        BestScore.SetText(Data.MaxScore + "");
    }
}

using UnityEngine;
using TMPro;

public class GamePopup : Popup
{
    public TextMeshProUGUI txt;
    public void OnClickBackButton()
    {
        Hide();
        SceneController.Instance.LoadHomeScene();
    }

    public void setCurrentScore(int score)
    {
        txt.SetText(score + "");
    }
}

using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Level1 : Level
{
    public CakeController cake;
    private int score;
    private bool isEnd = false;
    public float scaleValue = 1.5f;
    public Transform scaletranform;

    private void Awake()
    {
        score = 0;
        PopupController.Instance.GetPopup<GamePopup>().setCurrentScore(score);
        scaletranform.transform.DOScale(scaleValue, .01f);
    }
    public void spawnCake(Vector3 vector3)
    {
        var Cake = Instantiate(cake, scaletranform);
        Cake.setCanDrag(false);
        Cake.transform.position = vector3;
        Cake.rigid.bodyType = RigidbodyType2D.Dynamic;
        score = score + 1;
        if (score > Data.MaxScore)
        {
            Data.SetInt(Constant.MAX_SCORE, score);
        }
        PopupController.Instance.GetPopup<GamePopup>().setCurrentScore(score);
        Debug.Log("Max score - " + Data.MaxScore);
    }

    public void onClickBack()
    {
        SceneController.Instance.LoadHomeScene();
    }

    public void endLevel()
    {
        if (isEnd == false)
        {
            isEnd = true;
            Debug.Log("enddddddd");
            PopupController.Instance.GetPopup<WinPopup>().SetTotalScore(score);
            PopupController.Instance.Hide<GamePopup>();
            PopupController.Instance.Show<WinPopup>();
        }
    }

    public void SetScale()
    {
        scaleValue = scaleValue - 0.1f;
        scaletranform.transform.DOScale(scaleValue, .01f);
    }

    public float getScaleValue()
    {
        return scaleValue;
    }
}

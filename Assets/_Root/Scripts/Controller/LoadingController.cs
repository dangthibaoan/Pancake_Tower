using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadingController : Singleton<LoadingController>
{
    public Image LoadingBar;

    protected override void Awake()
    {
        base.Awake();

        LoadingBar.fillAmount = 0;
    }

    private void Start()
    {
        LoadingBar.DOFillAmount(1, 1).OnComplete(() =>
        {
            Data.SetBool(Constant.MUSIC_STATE, true);
            SceneController.Instance.LoadHomeScene();
        });
    }
}

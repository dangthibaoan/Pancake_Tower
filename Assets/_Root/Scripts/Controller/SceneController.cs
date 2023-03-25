using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class SceneController : Singleton<SceneController>
{
#if UNITY_EDITOR
    [MenuItem("Tools/Play")]
    public static void Play()
    {
        EditorSceneManager.OpenScene("Assets/_Root/Scenes/LoadingScene.unity");
        EditorApplication.isPlaying = true;
    }
#endif

    public void LoadLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}

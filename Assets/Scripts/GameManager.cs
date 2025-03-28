using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        Progress.OnProgressComplete += HandleProgressComplete;
    }

    private void OnDisable()
    {
        Progress.OnProgressComplete -= HandleProgressComplete;
    }

    void HandleProgressComplete()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}

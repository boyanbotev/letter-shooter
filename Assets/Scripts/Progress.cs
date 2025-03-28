using TMPro;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static event System.Action OnProgressComplete;
    public int progress = 0;
    public int maxProgress = 10;
    TextMeshProUGUI text;

    private void OnEnable()
    {
        LetterCollectionManager.OnCorrectCollect += HandleCorrectCollect;
        LetterCollectionManager.OnFalseCollect += HandleFalseCollect;
    }

    private void OnDisable()
    {
        LetterCollectionManager.OnCorrectCollect -= HandleCorrectCollect;
        LetterCollectionManager.OnFalseCollect -= HandleFalseCollect;
    }

    private void HandleCorrectCollect()
    {
        progress++;
        Debug.Log($"Progress: {progress}/{maxProgress}");
        UpdateProgress();

        if (progress >= maxProgress)
        {
            Debug.Log("Progress complete!");
            OnProgressComplete?.Invoke();
        }
    }

    private void HandleFalseCollect()
    {
        progress--;
        if (progress < 0)
        {
            progress = 0;
        }
        UpdateProgress();
        Debug.Log($"Progress: {progress}/{maxProgress}");
    }

    private void Awake()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(text.text);
    }

    private void Start()
    {
        UpdateProgress();
    }

    private void UpdateProgress()
    {
        text.text = $"Progress: {progress}/{maxProgress}";
    }
}

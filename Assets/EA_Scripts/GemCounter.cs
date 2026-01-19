using TMPro;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    public int collected = 0;
    public int toBeCollected = 10;
    public TMP_Text counterText;
    public static GemCounter Instance;

    public AudioClip audioLevelCompleted;
    public float audioVolume = 0.5f;

    private bool hasTriggeredUnlock = false;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddGem()
    {
        collected++;
        UpdateUI();

        if (!hasTriggeredUnlock && collected >= toBeCollected)
        {
            hasTriggeredUnlock = true;

            if (TaskProgress.Instance != null && audioLevelCompleted != null && AudioManager.Instance != null)
            {
                TaskProgress.Instance.CompleteBedTask();
                
                AudioManager.Instance.PlayOneShot(audioLevelCompleted, audioVolume);
                
                //Debug.Log("Bedroom task completed!");
            }
            else
            {
                Debug.LogError("TaskProgress is NULL — it is NOT in the scene!");
            }
        }
    }
    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = $"{collected}/{toBeCollected}";
        }
    }
}

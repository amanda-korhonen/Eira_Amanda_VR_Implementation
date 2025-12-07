using System;
using TMPro;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    public int collected = 0;
    public int toBeCollected = 10;
    public TMP_Text counterText;
    public static GemCounter Instance;

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

        if(!hasTriggeredUnlock && collected >= toBeCollected)
        {
            hasTriggeredUnlock = true;

            if (TaskProgress.Instance != null)
            {
                TaskProgress.Instance.moonDoorUnlocked = true;
                Debug.Log("Door unlocked.");
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

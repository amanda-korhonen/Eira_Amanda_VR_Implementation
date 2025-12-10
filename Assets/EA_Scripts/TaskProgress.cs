using System;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

public class TaskProgress : MonoBehaviour
{
    public static TaskProgress Instance;

    //use this to see if both tasks are completed
    public bool bedTaskCompleted = false;
    public bool potatoTaskCompleted = false;
    public event Action OnTaskCompleted;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void CompleteBedTask()
    {
        bedTaskCompleted = true;
        Debug.Log("Bedroom task marked as DONE.");
        OnTaskCompleted?.Invoke();
    }

    public void CompletePotatoTask()
    {
        potatoTaskCompleted = true;
        Debug.Log("Potato task marked as DONE.");
        OnTaskCompleted?.Invoke();
    }

}

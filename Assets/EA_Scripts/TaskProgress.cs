using JetBrains.Annotations;
using UnityEngine;

public class TaskProgress : MonoBehaviour
{
    public static TaskProgress Instance;
    public bool moonDoorUnlocked = false;

    


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
}

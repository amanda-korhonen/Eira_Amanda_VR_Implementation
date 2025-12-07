using UnityEngine;

public class TaskProgress : MonoBehaviour
{
    public static TaskProgress Instance;

    //use this to see if both tasks are completed
    public bool bedTaskCompleted = false;
    public bool potatoTaskCompleted = false;

    


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

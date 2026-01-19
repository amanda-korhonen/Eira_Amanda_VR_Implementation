using UnityEngine;

public class DoorSceneTransition : Interactive
{
    [SerializeField] private int targetScene;
    private Rigidbody rb;
    private SceneTransitionManager sceneTransitionManager;
    //Controls if a door is locked or unlocked at the start of the game
    [SerializeField] private bool isUnlocked = false;

    //All audio stuff
    public AudioClip audioClipDoorLocked;
    public float audioVolume = 0.5f;
    public AudioClip audioClipDoorUnlocked;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sceneTransitionManager = FindFirstObjectByType<SceneTransitionManager>();
        
        if (sceneTransitionManager == null)
        {
            Debug.LogError("SceneTransitionManager not found in the scene!");
        }

    }

    private void UnlockDoor()
    {
        isUnlocked = true;
        Debug.Log("Door is now unlocked");
    }

    public new void Interact()
    {
        //Checks if both tasks are completed edit if you add more tasks
        if (TaskProgress.Instance != null && 
        TaskProgress.Instance.bedTaskCompleted && 
        TaskProgress.Instance.potatoTaskCompleted)
        {
            UnlockDoor();
        } 

        if (!isUnlocked)
        {
            Debug.Log("Door is locked");
            if (audioClipDoorLocked != null && AudioManager.Instance != null )
            {
                AudioManager.Instance.PlayOneShot(audioClipDoorLocked, audioVolume);
            }
            return;
        }

        if (rb != null && sceneTransitionManager != null)
        {
            if (audioClipDoorUnlocked != null && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayOneShot(audioClipDoorUnlocked, audioVolume);
            }
            sceneTransitionManager.GoToSceneAsync(targetScene);

        }
    }
}

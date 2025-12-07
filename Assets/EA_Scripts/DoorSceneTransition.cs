using UnityEngine;

public class DoorSceneTransition : Interactive
{
    [SerializeField] private int targetScene;
    private Rigidbody rb;
    private SceneTransitionManager sceneTransitionManager;
    //Controls if a door is locked or unlocked at the start of the game
    [SerializeField] private bool isUnlocked = false;

    public AudioClip audioClipDoorLocked;
    public float audioVolume = 1.0f;
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
        //Checks if both tasks are completed
        if (TaskProgress.Instance != null && 
        TaskProgress.Instance.bedTaskCompleted && 
        TaskProgress.Instance.potatoTaskCompleted)
        {
            UnlockDoor();
        } else
        {
            Debug.Log("One or more tasks need to be completed first.");
        }
        
        if (!isUnlocked)
        {
            Debug.Log("Door is locked");
            if (audioClipDoorLocked != null)
            {
                GameObject tempAudioSourceLocked = new GameObject("TempAudioLocked");
                AudioSource audioSource = tempAudioSourceLocked.AddComponent<AudioSource>();
                audioSource.clip = audioClipDoorLocked;
                audioSource.volume = audioVolume;
                audioSource.Play();
                //Debug.Log("Playing audio clip with volume: " + audioVolume);
                Destroy(tempAudioSourceLocked, audioClipDoorLocked.length);
            }
            return;
        }

        if (rb != null && sceneTransitionManager != null)
        {
            if (audioClipDoorUnlocked != null)
            {
                GameObject tempAudioSourceUnlocked = new GameObject("TempAudioUnclocked");
                AudioSource audioSource = tempAudioSourceUnlocked.AddComponent<AudioSource>();
                audioSource.clip = audioClipDoorUnlocked;
                audioSource.volume = audioVolume;
                audioSource.Play();
                //Debug.Log("Playing audio clip with volume: " + audioVolume);
                Destroy(tempAudioSourceUnlocked, audioClipDoorUnlocked.length);
            }
            sceneTransitionManager.GoToSceneAsync(targetScene);
        }
    }
}

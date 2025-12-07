using UnityEngine;

public class DoorSceneTransition : Interactive
{
    [SerializeField] private int targetScene;
    private Rigidbody rb;
    private SceneTransitionManager sceneTransitionManager;
    //Controls if a door is locked or unlocked at the start of the game
    [SerializeField] private bool isUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sceneTransitionManager = FindFirstObjectByType<SceneTransitionManager>();
        
        if (sceneTransitionManager == null)
        {
            Debug.LogError("SceneTransitionManager not found in the scene!");
        }
        if (TaskProgress.Instance != null && TaskProgress.Instance.moonDoorUnlocked)
        {
            UnlockDoor();
        }

    }

    private void UnlockDoor()
    {
        isUnlocked = true;
        Debug.Log("Door is now unlocked");
    }


    public new void Interact()
    {
        if (!isUnlocked)
        {
            Debug.Log("Door is locked");
            return;
        }

        if (rb != null && sceneTransitionManager != null)
        {
            sceneTransitionManager.GoToSceneAsync(targetScene);
        }
    }
}

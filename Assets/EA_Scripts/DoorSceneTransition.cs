using UnityEngine;

public class DoorSceneTransition : Interactive
{
    [SerializeField] private int targetScene;
    private Rigidbody rb;
    private SceneTransitionManager sceneTransitionManager;
    //Controls if a door is locked or unlocked at the start of the game
    //[SerializeField] private bool isUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sceneTransitionManager = FindFirstObjectByType<SceneTransitionManager>();
        
        if (sceneTransitionManager == null)
        {
            Debug.LogError("SceneTransitionManager not found in the scene!");
        }
    }
    //TODO: make the lock unlock system

    public new void Interact()
    {
        if (rb != null && sceneTransitionManager != null)
        {
            sceneTransitionManager.GoToSceneAsync(targetScene);
        }
    }
}

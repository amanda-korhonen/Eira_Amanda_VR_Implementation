using UnityEngine;

public class DoorSceneTransition : Interactive
{
    [SerializeField] private int targetScene;
    private Rigidbody rb;
    private SceneTransitionManager sceneTransitionManager;

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

    public new void Interact()
    {
        if (rb != null && sceneTransitionManager != null)
        {
            sceneTransitionManager.GoToSceneAsync(targetScene);
        }
    }
}

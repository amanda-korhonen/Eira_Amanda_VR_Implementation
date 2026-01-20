using UnityEngine;

public class GemCollection : Interactive
{
    private Rigidbody rb;
    public AudioClip audioClip;
    public float audioVolume = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is create
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public new void Interact()
    {
        CollectionEvent();
    }
    void CollectionEvent()
    {
        if (audioClip != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShot(audioClip, audioVolume);
        }
        //Debug.Log("Gem collected!");

        if (GemCounter.Instance != null)
        {
            GemCounter.Instance.AddGem();
        }
        Destroy(gameObject);
    }
}

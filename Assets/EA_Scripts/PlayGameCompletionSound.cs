using UnityEngine;

public class PlayGameCompletionSound : MonoBehaviour
{
    public AudioClip audioGameCompleted;
    public float audioVolume = 0.25f;
    void Start()
    {
         if (audioGameCompleted != null && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayOneShot(audioGameCompleted, audioVolume);
            }
    }
}

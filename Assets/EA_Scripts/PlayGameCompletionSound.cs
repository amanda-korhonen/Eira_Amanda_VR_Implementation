using UnityEngine;

public class PlayGameCompletionSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip audioGameCompleted;
    void Start()
    {
         if (audioGameCompleted != null)
            {
                GameObject tempAudioSourceCompleted = new GameObject("TempAudioCompleted");
                AudioSource audioSource = tempAudioSourceCompleted.AddComponent<AudioSource>();
                audioSource.clip = audioGameCompleted;
                audioSource.volume = 0.25f;
                audioSource.Play();
                //Debug.Log("Playing audio clip with volume: " + audioVolume);
                Destroy(tempAudioSourceCompleted, audioGameCompleted.length);
            }
    }


}

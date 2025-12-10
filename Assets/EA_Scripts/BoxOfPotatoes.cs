using UnityEngine;
using TMPro;

public class BoxOfPotatoes : MonoBehaviour
{
    public int collected = 0;
    public int toBeCollected = 5;
    public TMP_Text counterText;

    //audio 
    public AudioClip audioClip;
    public AudioClip audioLevelCompleted;
    public float audioVolume = 1.0f;

    //room completion logic 
    private bool hasTriggeredUnlock = false;
    private void UpdateUI()
    {
        counterText.text = $"{collected}/{toBeCollected}";
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        var potato = other.GetComponent<PotatoType>();
        if (potato != null && potato.type == PotatoQuality.Good)
        {
            collected++;
            UpdateUI(); //update UI (aka counter) only when triggered
            CollectionEvent();

            if (!hasTriggeredUnlock && collected >= toBeCollected)
            {
                hasTriggeredUnlock = true;
                if (TaskProgress.Instance != null && audioLevelCompleted != null)
                {
                    TaskProgress.Instance.CompletePotatoTask();

                    GameObject tempAudioSourceCompleted = new GameObject("TempAudioCompleted");
                    AudioSource audioSource = tempAudioSourceCompleted.AddComponent<AudioSource>();
                    audioSource.clip = audioLevelCompleted;
                    audioSource.volume = 0.5f;
                    audioSource.Play();
                    //Debug.Log("Playing audio clip with volume: " + audioVolume);
                    Destroy(tempAudioSourceCompleted, audioLevelCompleted.length);
                    Debug.Log("Potato task completed!");
                }
                else
                {
                    Debug.LogError("TaskProgress is NULL — it is NOT in the scene!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var potato = other.GetComponent<PotatoType>();
        if (potato != null && potato.type == PotatoQuality.Good)
        {
            collected--;
            UpdateUI(); //update UI (aka counter) only when triggered¨

            //Took away the completion check if all potatoes are not present
            // to counteract that scenario when a player thinks that they are done  
            // but the potato yeeted itself when the player was not looking. 

            /*if(hasTriggeredUnlock && collected < toBeCollected)
            {
                TaskProgress.Instance.potatoTaskCompleted = false;
                Debug.Log("Potato task not yet done.");
            }else
            {
                Debug.LogError("TaskProgress is NULL — it is NOT in the scene!");
            }*/
        }
    }


    void CollectionEvent()
    {
        if (audioClip != null)
        {
            GameObject tempAudioSource = new GameObject("TempAudio");
            AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = audioVolume;
            audioSource.Play();
            //Debug.Log("Playing audio clip with volume: " + audioVolume);
            Destroy(tempAudioSource, audioClip.length);
        }

    }
}

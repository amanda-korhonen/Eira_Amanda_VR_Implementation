using UnityEngine;
using TMPro;

public class BoxOfPotatoes : MonoBehaviour
{
    public int collected = 0;
    public int toBeCollected = 5;
    public TMP_Text counterText;

    //audio 
    public AudioClip audioClip;
    public float audioVolume = 1.0f;

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var potato = other.GetComponent<PotatoType>();
        if (potato != null && potato.type == PotatoQuality.Good)
        {
            collected--;
            UpdateUI(); //update UI (aka counter) only when triggered
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

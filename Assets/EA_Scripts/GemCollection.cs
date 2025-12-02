using UnityEngine;
using Photon.Pun;
using System;

public class GemCollection : Interactive
{
    private Rigidbody rb;
    PhotonView pv;
    public AudioClip audioClip;
    public float audioVolume = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is create
    void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }

    public new void Interact()
    {
        if (pv == null) return;
        pv.RPC("CollectionEvent", RpcTarget.AllBuffered);

    }

    [PunRPC]
  
    void CollectionEvent()
    {
        if (audioClip != null)
        {
            GameObject tempAudioSource = new GameObject("TempAudio");
            AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = audioVolume;
            audioSource.Play();
            //Debug.Log("Playing audio clip at point with volume: " + audioVolume);
            Destroy(tempAudioSource, audioClip.length);
        }
        //Debug.Log("Gem collected!");
        Destroy(gameObject);

    }
}

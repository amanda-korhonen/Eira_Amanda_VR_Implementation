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
        pv.RPC("CollectionEvent", RpcTarget.All); 
        // Changed from .AllBuffered to All not sure if did anything
        // If multiplayer is implemented sometime could cause problems or smth

    }

    [PunRPC]
  
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

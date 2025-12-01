using UnityEngine;
using Photon.Pun;

public class GemCollection : Interactive
{
    private Rigidbody rb;
    PhotonView pv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Gem collected!");
            Destroy(this.rb);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using Photon.Pun;

public class GravityToggle : Interactive
{
    // Updated this to be able to see it in multiplayer on 17.11.2025
    PhotonView pv;
    private Rigidbody rb;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }
        
    public new void Interact()
    {
        if (pv == null) return;
        // When interacted, ask ALL players to kick the object
        pv.RPC("EnableGravity", RpcTarget.AllBuffered);
    }

    [PunRPC]

    // The logic does not work should return the position
    // of the cube and toggle off gravity
    void EnableGravity()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.useGravity = true;
    }
}

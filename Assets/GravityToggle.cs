using UnityEngine;
using Photon.Pun;

public class GravityToggle : Interactive
{
    // Updated this to be able to see it in multiplayer on 17.11.2025
    PhotonView pv;
    private Rigidbody rb;
    bool gravity = true;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }
        
    public new void Interact()
    {
        if (pv == null) return;
        // When interacted, ask ALL players to kick the object
        pv.RPC("SetGravity", RpcTarget.AllBuffered, gravity);
    }

    [PunRPC]

    // The logic does not work should return the position
    // of the cube and toggle off gravity
    void SetGravity(bool gravity)
    {
        if(gravity == true)
        {
            rb.useGravity = true;
        }else
        {
            rb.position = new Vector3(-1.27f, 1.8f, 1.81f);
            rb.useGravity = false;
            
        }
    }
}

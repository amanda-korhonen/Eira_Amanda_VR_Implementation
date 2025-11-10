using UnityEngine;

public class TwistGrab : Interactive
{
    Rigidbody rb;
    bool isGrabbed;

    public new void Interact()
    {
        isGrabbed = true;
        rb = GetComponent<Rigidbody>();
    }
   
}

using UnityEngine;

public class TwistGrab : Interactive
{
    Rigidbody rb;
    bool isGrabbed;

    public new void Interact()
    {
        isGrabbed = true;
        GetComponent<Rigidbody>().transform.Rotate(0,1,0);
    }
   
}

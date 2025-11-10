using UnityEngine;

public class GravityToggle : Interactive
{
    public new void Interact()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}

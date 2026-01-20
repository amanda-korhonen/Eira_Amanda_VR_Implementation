using UnityEngine;

public class GravityToggle : Interactive
{
    // Updated this to be able to see it in multiplayer on 17.11.2025
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
        
    public new void Interact()
    {
        EnableGravity();
    }

    // The logic does not work should return the position
    // of the cube and toggle off gravity
    void EnableGravity()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.useGravity = true;
    }
}

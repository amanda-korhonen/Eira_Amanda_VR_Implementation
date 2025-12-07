using UnityEngine;

public class GrabPotato : MonoBehaviour
{
    private Transform holdPointNow;
    private bool isGrabbed = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform point)
    {
        holdPointNow = point;
        isGrabbed = true;

        rb.isKinematic = true;
        rb.useGravity = true;

        transform.SetParent(point);
        transform.localPosition = Vector3.zero;
    }

    public void Release()
    {
        isGrabbed = false;
        rb.isKinematic = false;
        rb.useGravity = false;
        transform.SetParent(null);
    }
}

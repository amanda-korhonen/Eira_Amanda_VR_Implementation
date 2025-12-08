using Unity.VisualScripting;
using UnityEngine;

public class Grabbable : Interactive
{

    /*
    [SerializeField] float grabSpeed = 5f;

    static Transform currentObj = null;
    static Transform cam = null;

    Rigidbody rb;

    public static Transform holdPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public new void Interact()
    {
        //if nothing is being grabbed atm grab
        if (currentObj != transform)
        {
            currentObj = transform;
        }
        else
        {
            //if currently grabbing, drop
            currentObj = null;
        }
    }

    void Update()
    {
        if (!cam && Camera.main)
            cam = Camera.main.transform;

        //gravity on when potato is not grabbed
        rb.useGravity = currentObj != transform;

        //if potato is grabbed move it towards the player
        if (currentObj == transform && holdPoint != null)
        {
            Vector3 targetPoint = holdPoint.position;
            rb.linearVelocity = (targetPoint - transform.position) * grabSpeed;
        }
    }*/


    
    [SerializeField] float grabSpeed = 5f;
    public bool useGravity = true;
    static Transform grabbed = null;
    static Transform cam = null;
    Rigidbody rb;
    float grabDistance = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public new void Interact()
    {
        if (grabbed != transform)
        {
            grabbed = transform;
            //grabDistance = Vector3.Distance(cam.position, transform.position);
            grabDistance = 3.0f;
        }
        else
            grabbed = null;
    }

    void Update()
    {
        if (!cam && Camera.main)
            cam = Camera.main.transform;

        rb.useGravity = grabbed != transform && useGravity;

        if (grabbed == transform)
        {

            Vector3 targetPoint = cam.position + cam.forward * grabDistance;
            rb.linearVelocity = (targetPoint - transform.position) * grabSpeed;
        }
    }
}

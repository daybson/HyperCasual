using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    protected Vector3 torqueAxis;

    [SerializeField]
    protected float moveSpeed;

    [SerializeField]
    protected float torqueSpeed;

    protected Rigidbody rigidbody;

    [SerializeField]
    protected float maxAngularVelocity;

    [SerializeField]
    protected float maxVelocity;
    protected float sqrMaxVelocity;
     
    int c = 0;
    public bool score; 


    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.maxAngularVelocity = maxAngularVelocity;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 1.2f, Color.yellow);
        
        if (score)
            return;

        if (this.rigidbody.velocity.magnitude == 0 && this.rigidbody.angularVelocity.magnitude == 0)
        {
            if (Physics.Raycast(transform.position, transform.up, out RaycastHit r, 1.1f))
            {
                print("score!" + ++c);
                score = true;
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        score = false;
    }

    public void AddTorque()
    {
        this.rigidbody.AddTorque(torqueAxis * this.torqueSpeed, ForceMode.Impulse);

        if (this.rigidbody.velocity.normalized == Vector3.down)
            this.rigidbody.velocity = Vector3.zero;

        this.rigidbody.AddForce(Vector3.up * this.moveSpeed, ForceMode.Impulse);
    }
}

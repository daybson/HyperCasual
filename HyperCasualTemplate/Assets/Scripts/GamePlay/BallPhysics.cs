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
    [SerializeField] private float offset;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.maxAngularVelocity = maxAngularVelocity;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + Vector3.right * this.offset, Vector3.down*2, Color.yellow);
        
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
        //TODO: torque variável em função do tempo de touch
        this.rigidbody.AddTorque(this.torqueAxis * this.torqueSpeed, ForceMode.Impulse);
        
        //TODO: posição de aplicação da força em função do local do touch?
        this.rigidbody.AddForceAtPosition(Vector3.up * this.torqueSpeed, transform.position + Vector3.right * this.offset, ForceMode.Force);
        
        //if (this.rigidbody.velocity.normalized == Vector3.down)
        //    this.rigidbody.velocity = Vector3.zero;

        //this.rigidbody.AddForce(Vector3.up * this.moveSpeed, ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    protected Vector3 spawnPos;

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

    [SerializeField]
    private bool IsGround;
    int c = 0;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.maxAngularVelocity = maxAngularVelocity;
        //sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up, Color.yellow);

        if (this.rigidbody.velocity.magnitude == 0 && this.rigidbody.angularVelocity.magnitude == 0)
        {
            if (Physics.Raycast(transform.position, transform.up, out RaycastHit r, 1.1f))
            {
                print("score!" + ++c);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //print(transform.InverseTransformDirection(transform.up));

        //if (Physics.Raycast(transform.position, transform.up, out RaycastHit r, 1.1f))
        //{
        //    print("score!" + ++c);
        //}

        //IsGround = true;
        //if (transform.up == Vector3.up)

    }

    private void OnCollisionExit(Collision collision)
    {
        //IsGround = false;
    }

    public void AddTorque(Vector3 direction, float torque)
    {
        //if (IsGround)
        {
            //this.axisRotation = direction;
            this.rigidbody.AddTorque(Vector3.right * this.torqueSpeed, ForceMode.Impulse);


            if (this.rigidbody.velocity.normalized == Vector3.down)
                this.rigidbody.velocity = Vector3.zero;

            this.rigidbody.AddForce(Vector3.up * this.moveSpeed, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    protected Vector3 spawnPos;

    [SerializeField]
    protected Transform topPos;

    [SerializeField]
    protected Transform bottomPos;

    [SerializeField]
    protected float moveSpeed;

    [SerializeField]
    protected float torqueSpeed;

    protected Rigidbody rigidbody;

    [SerializeField]
    protected float maxAngularVelocity;

    protected Vector3 axisRotation;


    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.maxAngularVelocity = maxAngularVelocity;
    }


    public void AddTorque(Vector3 direction, float torque)
    {
        //this.axisRotation = direction;
        this.rigidbody.AddTorque(direction * torque * this.torqueSpeed);
    }

    public void MoveToTop()
    {
        transform.position = Vector3.MoveTowards(transform.position, topPos.position, moveSpeed * Time.deltaTime);
    }

    public void MoveToBottom()
    {
        transform.position = Vector3.MoveTowards(transform.position, bottomPos.position, moveSpeed * Time.deltaTime);

        if (transform.position == bottomPos.position && transform.rotation.eulerAngles.x % 90 != 0)
        {
            Debug.Log($"{transform.rotation.eulerAngles}");

            var up = Vector3.Dot(transform.forward, Vector3.up);
            var down = Vector3.Dot(transform.forward, Vector3.down);
            var forward = Vector3.Dot(transform.forward, Vector3.forward);
            var back = Vector3.Dot(transform.forward, Vector3.back);

            var min = Mathf.Min(new float[] { up, down, forward, back });

            if (min == up) transform.forward = Vector3.up;
            else if (min == down) transform.forward = Vector3.down;
            else if (min == forward) transform.forward = Vector3.forward;
            else if (min == back) transform.forward = Vector3.back;
        }
    }

    private bool IsUp() => transform.up == Vector3.up;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    protected float spinningTime;

    private bool IsHoldingDown;
    private bool IsReleased;

    [SerializeField]
    protected BallPhysics ball;


    private void Awake()
    {
        //Lean.Touch.LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
        //Lean.Touch.LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;

        this.ball = FindObjectOfType<BallPhysics>();

        Lean.Touch.LeanTouch.OnFingerTap += LeanTouch_OnFingerTap;
    }

    private void LeanTouch_OnFingerTap(Lean.Touch.LeanFinger obj)
    {
        this.ball.AddTorque();
    }

    private void Update()
    {
        /*
        if (this.IsHoldingDown)
        {
            this.spinningTime += Time.deltaTime;
            this.ball.AddTorque(this.ball.transform.right, this.spinningTime);
            //this.ball.MoveToTop();
        }
        else if (this.IsReleased)
        {
            //this.ball.MoveToBottom();
            this.spinningTime -= Time.deltaTime;
            this.spinningTime = Mathf.Clamp(this.spinningTime, 0, this.spinningTime);
        }
        */
    }



    private void LeanTouch_OnFingerDown(Lean.Touch.LeanFinger obj)
    {
        this.IsHoldingDown = true;
        this.IsReleased = false;
    }


    private void LeanTouch_OnFingerUp(Lean.Touch.LeanFinger obj)
    {
        this.IsHoldingDown = false;
        this.IsReleased = true;
    }

}

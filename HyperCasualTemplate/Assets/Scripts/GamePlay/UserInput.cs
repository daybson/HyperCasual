using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //[SerializeField]
    //protected float spinningTime;

    private bool IsHoldingDown;

    [SerializeField]
    protected Ball ball;
    protected BallPhysics ballp;
    //limitar quantidade de taps por jogada?
    //segurar para girar e soltar para parar? ****
    //tap para parar de girar?


    //[SerializeField]
    private float chargeMove;    
    [SerializeField]
    [Range(0.01f, 100)]
    private float chargeMoveFactor;
    [SerializeField]
    [Range(0.01f, 100)]
    private float unchargeMoveFactor;

    //[SerializeField]
    private float chargeSpin;
    [SerializeField]
    [Range(0.01f, 100)]
    private float chargeSpinFactor;
    [SerializeField]
    [Range(0.01f, 100)]
    private float unchargeSpinFactor;

    private void Awake()
    {
        //Lean.Touch.LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
        //Lean.Touch.LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
        Lean.Touch.LeanTouch.OnFingerTap += LeanTouch_OnFingerTap;

        ballp = FindObjectOfType<BallPhysics>();
    }


    private void Update()
    {
        return;

        if (this.IsHoldingDown)
        {
            this.chargeMove += this.chargeMoveFactor * Time.deltaTime;
            this.chargeSpin += this.chargeSpinFactor * Time.deltaTime;

            this.ball.MoveToTop(this.chargeMoveFactor);
        }
        else
        {
            this.chargeMove -= this.unchargeMoveFactor * Time.deltaTime;
            this.chargeSpin -= this.unchargeSpinFactor * Time.deltaTime;

            this.ball.MoveToBottom(this.unchargeMoveFactor);
        }

        this.chargeMove = Mathf.Clamp01(this.chargeMove);
        this.chargeSpin = Mathf.Clamp01(this.chargeSpin);

        //this.ball.AddTorque(Vector3.right, this.chargeSpin);
    }


    private void LeanTouch_OnFingerTap(Lean.Touch.LeanFinger obj)
    {
        this.ballp.AddTorque();
    }


    private void LeanTouch_OnFingerDown(Lean.Touch.LeanFinger obj)
    {
        this.IsHoldingDown = true;
    }


    private void LeanTouch_OnFingerUp(Lean.Touch.LeanFinger obj)
    {
        this.IsHoldingDown = false;
    }

}

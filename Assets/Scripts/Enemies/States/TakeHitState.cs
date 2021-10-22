using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHitState : State
{

    protected float takeHitDurationTime;
    protected D_TakeHitState stateData;
    
    //có quay mặt khi lại khi bị sát thương không 
    protected bool shouldFlipAfterTakeHit;
    public TakeHitState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_TakeHitState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        //kiểm tra xem có nên quay mặt lại khi bị nhận sát thương không
        if (shouldFlipAfterTakeHit)
        {
            entity.Flip();
        }

        entity.anim.SetTrigger("takeHit");
        takeHitDurationTime = startTime + stateData.takeHitTime;
        

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void setFlipAfterHit(bool shouldFlip)
    {
        Debug.Log(shouldFlip);
        shouldFlipAfterTakeHit = shouldFlip;
    }
}

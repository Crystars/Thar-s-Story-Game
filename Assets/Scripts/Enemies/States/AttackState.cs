using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    protected D_AttackState stateData;
    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.anim.SetTrigger(animBoolName);
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
}

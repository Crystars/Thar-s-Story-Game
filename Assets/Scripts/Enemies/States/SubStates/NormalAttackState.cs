using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackState : AttackState
{

    //khoảng thời gian mà trạng thái normal attack tồn tại
    protected float normalAttackDuaration;

    public NormalAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        normalAttackDuaration = Time.time + stateData.normalAttackTime;


      



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

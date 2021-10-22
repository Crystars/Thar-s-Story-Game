using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin_TakeHitState : TakeHitState

{
    Golbin enemy;
    public Golbin_TakeHitState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_TakeHitState stateData, Golbin enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        

        //nếu hết thời gian bị thương nhưng chưa hết máu thì chuyển sang trạng thái phát hiện nhân vật
        if(Time.time > takeHitDurationTime)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

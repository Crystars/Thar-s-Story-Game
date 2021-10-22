using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin_IdleState : IdleState
{

    


    Golbin enemy;
    public Golbin_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Golbin enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        //nếu hết thời gian đứng yên thì chuyển sang trạng thái move
        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }

        //nếu phát hiện ra nhân vật thì chuyển sang trạng thái phát hiện
        if (isPlayerInMinArgoRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

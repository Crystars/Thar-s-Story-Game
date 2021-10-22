using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        
        base.Enter();
        player.anim.SetBool("idle", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("idle", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(player.moveX != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.moveController.Move(0, false, player.isJump);
    }
}

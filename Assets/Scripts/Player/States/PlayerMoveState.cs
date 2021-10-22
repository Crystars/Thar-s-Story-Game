using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.anim.SetBool("move", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("move", false);
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(player.moveX == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.moveController.Move(player.moveX, false, player.isJump);
    }
}

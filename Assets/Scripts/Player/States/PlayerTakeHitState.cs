using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeHitState : PlayerState
{

    //thời gian mà trạng thái bị tấn công diễn ra
    private float takeHitDuration;

    public PlayerTakeHitState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
        player.anim.SetTrigger(animBoolName);

        takeHitDuration = Time.time + player.takeHitTime;

        //vào trạng thái TakeHit thì dừng tất cả hoạt động chạy nhảy lại
        player.moveController.Move(0, false, false);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //nếu đến thời gian diễn ra trạng thái này thì chuyển sang trạng thái đứng yên
        if(Time.time > takeHitDuration)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}

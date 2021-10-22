using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin_MoveState : MoveState
{
    Golbin enemy;
    public Golbin_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Golbin enemy) : base(entity, stateMachine, animBoolName, stateData)
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
       
        //nếu phát hiện ra người dùng trong khoảng cách min
        if (isPlayerInMinArgoRange)
        {
            //chuyển sang trạng thái đã phát hiện người dùng
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        //nếu enemy va chạm tường hoặc đã đi đến gần vực thẳm (đã đi đến thì isDectingLedge = false)
        // còn nếu vẫn còn đang đi đến hướng vực thẳm thì = true
        // hoặc nếu phát hiện người dùng đang đứng gần ở phía sau thì cũng chuyển sang trạng thái đứng yên và quay mặt lại
        else if (isDetectingWall || !isDectingLedge || isPlayerBehind)
        {

            //chuyển trạng thái thành Idle
            //trạng thái này đã được khởi tạo ở thằng enemy (lúc nó được start)
            //đồng thời ta set flip true để nó thực hiện quay đầu
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

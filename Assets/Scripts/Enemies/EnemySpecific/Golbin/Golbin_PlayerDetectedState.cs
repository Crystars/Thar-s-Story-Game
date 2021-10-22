using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin_PlayerDetectedState : PlayerDetectedState
{
    Golbin enemy;
    public Golbin_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Golbin enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        //nếu người dùng đi khỏi khoảng cách nhỏ
        if (!isPlayerInMinArgoRange)
        {

            // và rời ra luôn khoảng cách max thì cho enemy quay về trạng thái idle
            if (!isPlayerInMaxArgoRange)
            {
                //ta sẽ không thiết lập việc enemy flip nếu sau khi kết thúc trạng thái idle
                //bởi vì khi không phát hiện người dùng thì bản chất enemy sẽ đứng yên - sau khi đứng yên một khoảng thời gian mới tiếp tục di chuyển về phía trước (chuyển sang move state)
                //do đó, ta phải set việc flip = false để khi kết thúc idle state, enemy không thực hiện việc flip mà tiếp tục di chuyển về phía trước 
                enemy.idleState.SetFlipAfterIdle(false);
                //chuyển sang thái thái idle
                stateMachine.ChangeState(enemy.idleState);
            }
        }
        //nếu người dùng đi đến khoảng cách nhỏ
        else
        {
            //và nằm trong phạm vi tấn công thường và đã đến thời gian cho phép tấn công
            if (isPlayerInNormalAttackArea && Time.time > entity.nextNormalAttackDuration )
            {
                //chuyển sang trạng thái tấn công
                stateMachine.ChangeState(enemy.normalAttackState);
            }
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//trạng thái sau khi phát hiện người dùng ở trong khoảng cách min - max
public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;

    protected bool isPlayerInMinArgoRange;
    protected bool isPlayerInMaxArgoRange;

    //player có đi vào vùng tấn công không
    protected bool isPlayerInNormalAttackArea;


    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        //khi mới vào state phát hiện player - thì ta để enemy đứng yên lại (vì có thể từ move state chuyển qua đây)
        // bằng cách là ta set vận tốc = 0
        entity.SetVelocity(0f);

        //ở trạng thái này, sau khi đã phát hiện ra player khi ta
        // tiếp tục kiểm tra player vẫn tiếp tục ở trong khoảng cách max min phải không
        isPlayerInMinArgoRange = entity.CheckPlayerInMinArgoRange();
        isPlayerInMaxArgoRange = entity.CheckPlayerInMaxArgoRange();
        isPlayerInNormalAttackArea = entity.CheckPlayerInNormalAttackArea();
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
        //ở trạng thái này, sau khi đã phát hiện ra player khi ta
        // tiếp tục kiểm tra player vẫn tiếp tục ở trong khoảng cách max min phải không
        isPlayerInMinArgoRange = entity.CheckPlayerInMinArgoRange();
        isPlayerInMaxArgoRange = entity.CheckPlayerInMaxArgoRange();
        isPlayerInNormalAttackArea = entity.CheckPlayerInNormalAttackArea();
    }
}

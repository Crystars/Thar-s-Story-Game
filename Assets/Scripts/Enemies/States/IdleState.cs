using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//trạng thái đứng yên của Enemy
public class IdleState : State
{
    protected D_IdleState stateData;

    //biến kiểm tra xem - có flip sau khi ở trạng thái Idle hay không
    protected bool flipAfterIdle;
    //biến kiểm tra xem thời gian đứng yên hết chưa
    protected bool isIdleTimeOver;

    protected bool isPlayerInMinArgoRange;

    //giá trị thời gian trạng thái đứng yên
    protected float idleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        //khi ở trạng thái Idle - thì set vận tốc là 0f
        entity.SetVelocity(0f);

        //mới vào thì ta thiết lập là chưa hết thời gian đứng yên
        isIdleTimeOver = false;
        //ở trang thái này - ta phải check xem nhân vật có đi đến khoảng cách min của quái vật không
        //để chuyển quái vật sang trạng thái đã phát hiện player
        isPlayerInMinArgoRange = entity.CheckPlayerInMinArgoRange();
        //tạo ngẫu nhiên thời gian đứng yên
        SetRandomIdleTime();
        
    }

    public override void Exit()
    {
        base.Exit();

        //nếu khi thoát ra khỏi state hiện tại
        // và có set giá trị quay = true
        // thì tiến hành quay mặt enemy
        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //kiểm tra xem
        //thời gian hiện tại
        //với thời gian người dùng đã đứng yên = thời gian vào state + thời gian cho phép đứng yên (idleTime)
        if(Time.time >= startTime + idleTime)
        {
            //nếu hết thời gian đứng yên thì
            isIdleTimeOver = true;

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //ở trang thái này - ta phải check xem nhân vật có đi đến khoảng cách min của quái vật không
        //để chuyển quái vật sang trạng thái đã phát hiện player
        isPlayerInMinArgoRange = entity.CheckPlayerInMinArgoRange();
    }

    public void SetFlipAfterIdle (bool flip)
    {
        flipAfterIdle = flip;
    }
    
    //tạo ngẫu nhiên thời gian idle time
    private void SetRandomIdleTime()
    {
        //tạo ngẫu nhiên thời gian đứng yên
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}

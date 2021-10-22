using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//trạng thái di chuyển của nhân vật
public class MoveState : State
{
    protected D_MoveState stateData;

    //biến xác định xem rằng - có phải enemy đang phát hiện ra tường hay không
    protected bool isDetectingWall;
    //tương tự đối với vực thẳm
    protected bool isDectingLedge;
    //có phát hiện người dùng trong cái khoảng cách nhỏ không
    protected bool isPlayerInMinArgoRange;
    //có phát hiện ra người dùng đang đứng ở gần phía sau không
    protected bool isPlayerBehind;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    //ghi đè lại hàm thông báo tham gia vào state
    public override void Enter()
    {
        base.Enter();

        //gọi hàm thiết lạp giá trị velocity cho enemy
        entity.SetVelocity(stateData.movementSpeed);
        isDetectingWall = entity.CheckWall();
        isDectingLedge = entity.CheckLedge();
        isPlayerInMinArgoRange = entity.CheckPlayerInMinArgoRange();
        isPlayerBehind = entity.CheckPlayerBehind();
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

        //các hàm kiểm tra check liên quan đến Raycast (liên quan đến vậy lý) - do đó, ta nên để ở phần update vật lý
        isDetectingWall = entity.CheckWall();
        isDectingLedge = entity.CheckLedge();
        isPlayerInMinArgoRange = entity.CheckPlayerInMinArgoRange();
        isPlayerBehind = entity.CheckPlayerBehind();

    }
}

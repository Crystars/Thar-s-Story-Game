using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{


    //object game mà state đang nắm giữ
    protected Player player;
    //đối tượng để tương tác với các state
    protected PlayerStateMachine stateMachine;
    //giá trị thiết lập animation
    protected string animBoolName;
    //thời gian bắt đầu state
    public float startTime { get; protected set; }

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        player.anim.SetBool(animBoolName, true);
       
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void DoChecks()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//là một lớp chứa các methods mà các state sẽ sử dụng
public class State
{
    protected FiniteStateMachine stateMachine;
    //đối tượng enemy mà state này thuộc về
    protected Entity entity;
    //thời gian mà enemy bắt đầu vào state
    protected float startTime;

    //một giá trị có thể dùng để bật/tắt animation của đối tượng chứa State
    protected string animBoolName;

    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    //hàm có kiểu virtual nghĩa là có thể được override lại (định nghĩa lại) ở lớp con
    public virtual void Enter()
    {
        startTime = Time.time;
        //ta khởi động một animation của state hiện tại
        entity.anim.SetBool(animBoolName, true);

        
    }
    public virtual void Exit()
    {
        //ta tắt animation của state hiện tại
        entity.anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {
        //kiểm tra chết ở đây, bởi vì ở bất kì state nào
        // thì nhân vật đều có thể bị chết
    }

    public virtual void PhysicsUpdate()
    {

    }
}
   



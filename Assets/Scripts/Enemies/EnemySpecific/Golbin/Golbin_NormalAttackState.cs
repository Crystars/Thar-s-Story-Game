using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin_NormalAttackState : NormalAttackState
{
    Golbin enemy;
    bool isAttacked; // kiểm tra xem - đã thực hiện tấn công chưa
    public Golbin_NormalAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState stateData, Golbin enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        isAttacked = false;

        

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //nếu đã hết thời gian tồn tại - chuyển sang trạng thái phát hiện người chơi
        if (Time.time > normalAttackDuaration)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else
        {
            //nếu đã tấn công rồi thì không chạy hàm tấn công nữa - để tránh gây ra nhiều đợt sát thuognw sau mỗi frame
            if (isAttacked) return;
            //gọi hàm tấn công thường - nếu tấn công đã trúng người chơi thì nhận được giá trị true
            isAttacked = entity.NormalAttack();
            

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttackState : PlayerAttackState
{

    public float attackDurationTime;

    public PlayerNormalAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        //khởi động animation
        player.anim.SetTrigger(animBoolName);

        

        //thu thập các enemy bị tấn công

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.attackPoint.position, player.attackRange,player.whatIsEnemy);

        foreach(Collider2D i in hitEnemies)
        {
            //vì mỗi enemy đều có 2 lớp là Enemy (cót thể tên khác như Golbin) và một lớp con là Alive
            //khi ta tấn công enemy là tấn công trúng lớp TakeDamage - con của Alive
            
            // do đó ta phải lấy thằng Enemy là lớp cha trên cùng để tương tác với code
            // Mặc dù mỗi chủng loại quái vật sẽ được thêm code riêng như Golbin như có class Golbin
            // nhưng các class này đều kế thừa từ entity - do đó ta lấy ra Component entity cũng hợp lệ
            Entity enemy = i.transform.parent.parent.gameObject.GetComponent<Entity>();

            //cho vật bị sát thương: số sát thương và hướng hiện tại của nhân vật
            enemy.TakeHit(player.normalDamage, player.transform.localScale.x);

           


        }

        
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //sau một khoảng thời gian thì quay lại trang thái idle
        //nếu thời gian hiện tại > khoảng thời gian tấn công thì chuyển sang trạng thái idle
        if(Time.time >= startTime + player.normalAttackDuration)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

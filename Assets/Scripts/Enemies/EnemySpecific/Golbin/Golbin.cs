using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin : Entity
{

    //khai báo các states
    public Golbin_IdleState idleState { get; private set; }
    public Golbin_MoveState moveState { get; private set; }
    public Golbin_PlayerDetectedState playerDetectedState { get; private set; }
    public Golbin_TakeHitState takeHitState { get; private set; }

    public Golbin_NormalAttackState normalAttackState { get; private set; }


    //khai báo các dữ liệu cho từng state
    [SerializeField]
    D_MoveState moveStateData;
    [SerializeField]
    D_IdleState idleStateData;
    [SerializeField]
    D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    D_TakeHitState takeHitStateData;
    [SerializeField]
    D_AttackState attackStateData;

    //khoảng thời gian có thể chuyển sang trạng thái TakeHit tiếp theo
    private float nextTakeHitDuration;


    public override void Start()
    {
        base.Start();

        //khởi tạo các states
        idleState = new Golbin_IdleState(this, stateMachine, "idle", idleStateData, this);
        moveState = new Golbin_MoveState(this, stateMachine, "move", moveStateData, this);
        playerDetectedState = new Golbin_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        takeHitState = new Golbin_TakeHitState(this, stateMachine, "takeHit", takeHitStateData, this);
        normalAttackState = new Golbin_NormalAttackState(this, stateMachine, "normalAttack", attackStateData, this);

        nextTakeHitDuration = Time.time;

        //khởi động state đầu tiên là idle
        stateMachine.Initialize(idleState);

    }

    public override void TakeHit(float damage, float dameDirection)
    {
        base.TakeHit(damage, dameDirection);

        //nếu hết máu thì tự hủy
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        // chuyển sang trạng thái bị tấn công nếu đã qua khoảng thời gian cho phép chuyển sang trạng thái này
        if (Time.time > nextTakeHitDuration)
        {

            //nếu mà hướng của enemy (tính dựa theo góc quay y hiện tại của enemy) bị trùng với huognws của nguồn sát thương (cả hai đều quay về cùng 1 phía)
            // thì ta phải set là quay mặt enemy lại
            takeHitState.setFlipAfterHit(aliveGO.transform.rotation.y * dameDirection > 0);
            stateMachine.ChangeState(takeHitState);
            nextTakeHitDuration = Time.time + takeHitStateData.nextTakeHitTime;
        }
        else
        {
            //ngược lại thì cứ ở trạng thái hiện tại (đứng yên hoặc ở trạng thái phát hiện người dùng
            if(stateMachine.currentState == idleState || stateMachine.currentState == playerDetectedState)
            {
                return;
            }
            //khi nhận sát thương thì đứng yên nhưng set không quay mặt
            idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(idleState);
        }
    }


}

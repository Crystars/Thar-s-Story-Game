using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //đói tượng điều khiển state
    public PlayerStateMachine stateMachine;

    //khái báo các state
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerNormalAttackState normalAttackState { get; private set; }
    public PlayerTakeHitState takeHitState { get; private set; }
    

    //trình điều khiển di chuyển
    
    public CharacterController2D moveController;

    public Animator anim { get; private set; }

    public float moveSpeed;

    public float moveX { get; private set; }
    public bool isJump { get; private set; }

    //các thuộc tính cơ bản của nhân vật
    public float normalDamage; // số sát thương gây ra bởi tấn công thường
    public float maxHealth;
    private float currentHealth;

    //các thuộc tính chung liên quan đến tấn công
    public LayerMask whatIsEnemy;

    //các thuộc tính liên quan đến tấn công thường
    
    public Transform attackPoint; //điểm tấn công
    public float attackRange; // phạm vi tấn công
    public float normalAttackDuration; // thời gian mà một tấn công thường diễn ra
    public float waitNormalAttack; // thời gian chờ cho một tấn công thường tiếp theo xảy ra 
    private float nextNormalAttackDuration; // xác định thời gian xảy ra cuộc tấn công thường tiếp theo


    //các thuộc tính liên quan đến bị tấn công
    public float takeHitTime; // thời gian mà trạng thái bị tấn công diễn ra 
    public float nextTakeHitTime; // thời gian mà trạng thái bị tấn công diễn ra
    private float nextTakeHitDuration; //xác định thời gian cho lần bị tấn công tiếp theo
    
    private void Awake()
    {
        //khởi tạo state machine
        stateMachine = new PlayerStateMachine();
        //khởi tạo bộ điều khiển animation
        anim = GetComponent<Animator>();


        //khởi tạo các state
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        normalAttackState = new PlayerNormalAttackState(this, stateMachine, "normalAttack");
        takeHitState = new PlayerTakeHitState(this, stateMachine, "takeHit");
        
    }

    //khi bắt đầu nhân vật thì set trạng thái đứng im trước
    private void Start()
    {
        stateMachine.Initialize(idleState);


        moveX = 0;
        isJump = false;
        nextNormalAttackDuration = Time.time;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();

        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        isJump = Input.GetButton("Jump");

        //nếu nhấn nút J => tấn công thường và đã đến thời gian cho phép tấn công thường
        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextNormalAttackDuration)
        {
            stateMachine.ChangeState(normalAttackState);
            nextNormalAttackDuration = Time.time + waitNormalAttack;
        }

    }

    //bị tấn công - nhận vào một lượng sát thương
    public void TakeHit(float damage)
    {
        currentHealth -= damage;
        //nếu tới thời gian cho phép rơi vào trạng thái TakeHit thì đổi sang nó
        if(Time.time > nextTakeHitDuration)
        {
            //stateMachine.ChangeState(takeHitState);
            //set lại thời gian cho phép rơi vào trạng thái TakeHit
            nextTakeHitDuration = Time.time + nextTakeHitTime;
        }
        //ngược lại thì chuyển sang trạng thái đứng yên
        else
        {
            //stateMachine.ChangeState(idleState);
        }
        stateMachine.ChangeState(takeHitState);
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

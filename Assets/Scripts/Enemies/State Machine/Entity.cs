using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// đây là một lớp cơ bản dành cho các enemies của chúng ta
public class Entity : MonoBehaviour
{

    public FiniteStateMachine stateMachine;

    //hướng đối mặt của enemy
    public int facingDirection { get; private set; }

    //đối tượng lưu trữ dữ liệu của Enity
    [SerializeField]
    public D_Entity entityData;
    [SerializeField]
    public D_Status statusData;

    //mối đối tượng enemy sẽ có một Rigidbody
    public Rigidbody2D rb { get; private set; }
    //tất nhiên là phải có thêm animation
    public Animator anim { get; private set; }

    //Alive Game Object - một đối tượng để chỉ ra rằng game object chính vẫn còn sống
    public GameObject aliveGO { get; private set; }

    //máu hiện tại của enemy
    public float currentHealth { get; private set; }


   

    

    //thời gian tiếp theo mà enemy được phép tấn công thường
    public float nextNormalAttackDuration { get; private set; }

    

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform playerBehindCheck;
    [SerializeField]
    //điểm tấn công của enemy
    public Transform attackPoint;
    [SerializeField]
    //khu vực phát hiện người chơi đi vào để triển khai tấn công
    public Transform attackAreaCheck;



    //thay vì ta phải tạo ra mọt biến vector2 bằng cách new
    //thì ta có thể tạo ra một biến rỗng như thế này rồi set giá trị mới cho thuận tiện tính toán
    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        //gán hướng quay mặt ban đầu
        facingDirection = 1;

        //tìm thằng con của thằng có Tag là Alive và lấy gameObject của nó
        aliveGO = transform.Find("Alive").gameObject;
        //ta lấy được rigid body
        rb = aliveGO.GetComponent<Rigidbody2D>();
        //lấy được animation
        anim = aliveGO.GetComponent<Animator>();

        //set máu cho enemy
        currentHealth = statusData.maxHealth;

        //set thời gian cho phép lần tấn công tiếp theo
        nextNormalAttackDuration = Time.time;

        //khởi tạo đối tượng quản lý state
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        //thực hiện hành vi update logic của state hiện tại
        // state tương ứng sẽ tự thực hiện hành động
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        //thực hiện hành vi update physics của state hiện tại
        // state tương ứng sẽ tự thực hiện hành động
        stateMachine.currentState.PhysicsUpdate();
    }

    //hàm thiết lập vận tốc của enymy
    public virtual void SetVelocity(float velocity)
    {
        //ta tạo ra một giá trị vận tốc mới (theo chiều x) và để biến velocityWorkspace nắm giữ
        // dòng facingDirection * velocity nghĩa là ta xác định hướng đi (trái hay phải) của enemy
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);

        //sau đó, ta update vào enemy
        rb.velocity = velocityWorkspace;

    }

    //hàm kiểm tra va chạm vách tường
    public virtual bool CheckWall()
    {
        //ta hiểu hàm Raycast: để là một hàm sẽ xác định những vật thể nào va chạm với tia mà nó sinh ra
        //cụ thể là nó sẽ sinh ra một tia ray (có độ dài là entityData.wallCheckDistance) - nó sẽ kéo dài từ điểm bắt đầu đến hết độ dài của nó
        //điểm bắt đầu là wallCheck.position
        // và hướng của nó là (aliveGO.transform.right - theo Unity 2D thì đây là hướng X)
        // và nó sẽ không có tác dụng (bỏ qua) với những Layer nào (entityData.whatIsGround) -đây là một tham số tùy chọn
        //những vật thể nào bị tia ray này đụng trúng thì sẽ được phát hiện - tia ray vẫn tiếp tục chạy đến hết độ dài của nó
        //trong ví dụ này thì ta dùng để kiểm tra va chạm giữa enemy với bức tường
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    //hàm kiểm tra xem là người dùng có đang đi đến gần mõm của tile không (chuẩn bị rơi xuống)
    //nếu true: nghĩa là vẫn đang đi đến - chứ chưa đến gần
    //nếu false: nghĩa là đã đến gần rồi - chuẩn bị rơi xuống
    public virtual bool CheckLedge()
    {
        //công dụng tương tự như hàm trên nhưng nó dành cho vực thẳm - nên sẽ kiểm tra theo chiều y
        //ở cái hướng  Vector2.down ta không dùng aliveGO.transform.down vì không tồn tại down trong Tranform
        //thêm nữa là việc kiểm tra vực thẳm không phụ vào hướng của enemy
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinArgoRange()
    {
        //kiểm tra xem tia ray được sinh ra có chạm trúng player trong khoảng cách min hay không 
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMaxArgoRange()
    {
        //kiểm tra xem tia ray được sinh ra có chạm trúng player trong khoảng cách max hay không 
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    //kiểm tra người chơi có đứng ở đằng sau với khoảng cách gần hay không
    public virtual bool CheckPlayerBehind()
    {
        //check ở phía sau nên ta sẽ tạo ra một ray chiếu về phía sau = -aliveGO.transform.right
        return Physics2D.Raycast(playerBehindCheck.position, -aliveGO.transform.right, entityData.playerBehindDistance, entityData.whatIsPlayer);
    }

    //kiểm tra xem - người chơi có vào phạm vi cho phép tấn công thường không
    public virtual bool CheckPlayerInNormalAttackArea()
    {
        //nếu lớn > 0 => player đã vào phạm vi tấn công
        return Physics2D.OverlapCircleAll(attackAreaCheck.position, entityData.normalAttackAreaRange, entityData.whatIsTakeDamage).Length > 0;
    }

    //hàm quay mặt
    public virtual void Flip()
    {
        //thay đổi giá trị hướng đối mặt của enemy
        facingDirection *= -1;
        //thực hiện xoay cái thằng aliveGO

        //quay 180 có thể xoay trái hoặc phải
        aliveGO.transform.Rotate(0f, 180f, 0f);

        //Vector3 aliveScale = aliveGO.transform.localScale;
       // aliveGO.transform.localScale = new Vector3(aliveScale.x * -1, aliveScale.y, aliveScale.z);
    }

    //hàm nhận sát thương
    //dameDirection: sát thương đến từ hướng nào (dựa vào scale của player - < 0 => player đang quay về bên trái và ngược lại)
    public virtual void TakeHit(float damage, float dameDirection)
    {
        currentHealth -= damage;
        
        
    }

    //thực hiện tấn công thường - nếu đã tấn công trúng người chơi thì return true -
    //ngược lại chưa trúng hay không thể thực hiện tấn công thì return false
    public virtual bool NormalAttack()
    {

        //set lại thời gian lần tấn công tiếp theo

        nextNormalAttackDuration = Time.time + entityData.nexNormaltAttackTime;

        //vì cái thằng attackPoint sẽ được active thì animation vung kiếm đến khúc giữa
        //các anmation còn lại thì attackPoint ở trạng thái active false
        // do đó ta sẽ chỉ tấn công thì active = true
        if (attackPoint.gameObject.active == false) return false;

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, entityData.normalAttackRange, entityData.whatIsTakeDamage);

        foreach(Collider2D i in hits)
        {
            //nếu tấn công trúng người chơi
            if (i.CompareTag("Player"))
            {
                Player player = i.GetComponent<Player>();
                player.TakeHit(statusData.normalAttackDamage);
                return true;
            }
        }

        

        return false;
        
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireSphere(attackPoint.position, entityData.normalAttackRange);
    }




}

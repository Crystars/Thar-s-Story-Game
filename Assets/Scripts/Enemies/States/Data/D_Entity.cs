using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dòng dưới đây cho phép ta tạo thêm đối tượng dữ liệu cho các thuộc tính của class này
//lúc này unity sẽ thêm cho ta một asset để thêm dữ liệu menu context của unity
//khi ta nhấn chuột phải vào cửa sổ asset - ta sẽ thấy nút Create và dựa theo nhugnwx gì bên dưới ta sẽ thấy một menu phân cấp như sau
// Data => Entity Data => Base Data

[CreateAssetMenu(fileName = "newEntityData",menuName ="Data/Entity Data/Base Data")]
//lưu trữ dữ liệu enemy
public class D_Entity : ScriptableObject {
    //khoảng cách kiểm tra va chạm tường
    public float wallCheckDistance = 0.2f;
    //khoảng cách kiểm tra va chạm vực thẳm
    public float ledgeCheckDistance = 0.4f;


    //khoảng cách phát hiện ra người dùng ngắn nhất - khi người dùng đi đến khoảng cách này thì mới enemy mới phát hiện ra người dùng
    public float minAgroDistance = 3f;
    //khoảng cách này tuy xa hơn khoảng cách min, nhưng nó sẽ xảy ra khi người dùng vào min
    //sử dụng khoảng cách này để xác định người dùng có ra khỏi phạm vi phát hiện chưa hoặc có thể làm gì đó với khoảng cách này
    public float maxAgroDistance = 4f;

    //khoảng cách để phát hiện ra người chơi đứng ở phía sau
    public float playerBehindDistance = 4f;

    //những thứ được xem là player
    public LayerMask whatIsPlayer;

    //Những thứ được xem là mặt đất
    public LayerMask whatIsGround;

    //bán kính tấn công thường
    public float normalAttackRange;

    //bán kính khu vực phát hiện người chơi đi vào để tấn công
    public float normalAttackAreaRange;

    //những đối tượng sẽ bị tấn công
    public LayerMask whatIsTakeDamage;

    //thời gian cho phép lần tấn công thường tiếp theo xảy ra
    public float nexNormaltAttackTime;

    
}

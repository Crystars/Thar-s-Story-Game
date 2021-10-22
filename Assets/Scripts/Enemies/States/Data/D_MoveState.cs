using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//dòng dưới đây cho phép ta tạo thêm đối tượng dữ liệu cho các thuộc tính của class này
//lúc này unity sẽ thêm cho ta một asset để thêm dữ liệu menu context của unity
[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
//dữ liệu liên quan đến Move State
//ScriptableObject: cho phép ta tạo ra một lớp dùng để lưu trữ lượng lớn dữ liệu
//trong trường hợp này ta sẽ sử dụng nó để lưu các biến liên quan đến MoveState
public class D_MoveState : ScriptableObject
{
    //tốc độ di chuyển
    public float movementSpeed = 3f;
}

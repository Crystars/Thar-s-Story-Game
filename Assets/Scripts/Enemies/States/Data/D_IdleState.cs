using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dòng dưới đây cho phép ta tạo thêm đối tượng dữ liệu cho các thuộc tính của class này
//lúc này unity sẽ thêm cho ta một asset để thêm dữ liệu menu context của unity

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
//Dữ liệu liên quan đến Idle State
public class D_IdleState : ScriptableObject
{
    //thời gian đứng yên tối thiểu
    public float minIdleTime = 1f;
    //thời gian đứng yên tối đa
    public float maxIdleTime = 2f;
}

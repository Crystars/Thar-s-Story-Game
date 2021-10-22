using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newTakeHitStateData", menuName = "Data/State Data/TakeHit State")]
public class D_TakeHitState : ScriptableObject
{
    // thời gian nhận sát thương
    public float takeHitTime;

    //thời gian để chuyển sang trạng thái nhận sát thương tiếp theo (có thể không ở trạng thái này nhưng vẫn mất máu)
    public float nextTakeHitTime;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//các chỉ số của đối tượng
[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Status Data")]
public class D_Status : ScriptableObject
{
    //lượng máu tối đa
    public float maxHealth;
    //sát thương đánh thường
    public float normalAttackDamage;
    
}

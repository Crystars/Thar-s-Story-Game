using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBlocker : MonoBehaviour
{
    public BoxCollider2D characterCollider;
    public BoxCollider2D blockerCollider;
    //collider tròn ở phần thân dưới
    public CircleCollider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(characterCollider, blockerCollider);
        if (bodyCollider)
        {
            Physics2D.IgnoreCollision(bodyCollider, blockerCollider);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

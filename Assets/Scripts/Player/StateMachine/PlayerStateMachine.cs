using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
 
    public PlayerState currentState { get; set; }

    //phương thức thiết lập state
    public void Initialize(PlayerState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        //thoát khỏi state cũ trước
        currentState.Exit();

        //thiết lập state mới
        currentState = newState;
        currentState.Enter();
    }
}

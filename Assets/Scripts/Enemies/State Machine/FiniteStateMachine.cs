using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//có thể xem lớp này như là một nơi để quản lý state
public class FiniteStateMachine
{
   public State currentState { get; private set; }


    //hàm thiết lập state ban đầu khi bắt đầu game
    public void Initialize(State startingState)
    {
        currentState = startingState;
        //khi thiết lập state thì thông báo là mới vào state
        currentState.Enter();
    }

    //hàm thay đổi state
    public void ChangeState(State newState)
    {
        //thông báo là thoát khỏi state cũ
        currentState.Exit();
        //gán state mới
        currentState = newState;
        //thông báo mới vào state
        currentState.Enter();
    }

}

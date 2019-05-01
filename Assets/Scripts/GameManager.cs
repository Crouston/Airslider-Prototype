using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State{CheckArrow,CheckPower,Play,Wait};

    public State playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = State.CheckArrow;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetNextState()
    {
        if (playerState != State.Wait)
        {
            playerState += 1;
        }
        else
        {
            playerState = State.CheckArrow;
        }
    }
}

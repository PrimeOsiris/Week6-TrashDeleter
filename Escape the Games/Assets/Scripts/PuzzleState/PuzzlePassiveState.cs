using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePassiveState : PuzzleBaseState
{

    public override void EnterState(PuzzleStateManager state)
    {

    }
    public override void OnUpdateState(PuzzleStateManager state)
    {
        
    }
    public override void OnStateCollision(PuzzleStateManager state, Collision collision)
    {
        if (state.gameObject.CompareTag("HouseLock") && collision.gameObject.layer == 6)
        {
            state.switchState(state.incorrectState);
        }
        if (state.gameObject.CompareTag("HotelLock") && collision.gameObject.layer == 6)
        {
            state.switchState(state.SolvedState);
        }
        if (state.gameObject.CompareTag("HotelLock") && collision.gameObject.layer == 7)
        {
            state.switchState(state.incorrectState);
        }
        if (state.gameObject.CompareTag("HouseLock") && collision.gameObject.layer == 7)
        {
            state.switchState(state.SolvedState);
        }
    }
}

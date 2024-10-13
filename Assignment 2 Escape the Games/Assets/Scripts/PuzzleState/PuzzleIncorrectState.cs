using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleIncorrectState : PuzzleBaseState
{
    public override void EnterState(PuzzleStateManager state)
    {
        state.incorrectSound.PlayOneShot(state.incorrectSound.clip, 0.5f);
    }
    public override void OnUpdateState(PuzzleStateManager state)
    {
        state.switchState(state.passiveState);
    }
    public override void OnStateCollision(PuzzleStateManager state, Collision collision)
    {
        
    }
}
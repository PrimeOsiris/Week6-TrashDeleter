using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;

public class PuzzleSolvedState : PuzzleBaseState
{
    public override void EnterState(PuzzleStateManager state)
    {
        state.correctSound.PlayOneShot(state.correctSound.clip, 0.5f);
        Object.Destroy(state.linkedElement);
    }
    public override void OnUpdateState(PuzzleStateManager state)
    {

    }
    public override void OnStateCollision(PuzzleStateManager state, Collision collision)
    {
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class PuzzleBaseState
{
    public abstract void EnterState(PuzzleStateManager state);
    public abstract void OnUpdateState(PuzzleStateManager state);
    public abstract void OnStateCollision(PuzzleStateManager state ,Collision collision);
}
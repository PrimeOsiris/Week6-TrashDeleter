using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStateManager : MonoBehaviour
{
    [Header("Linked Game Elements")]
    public GameObject linkedElement;
    public AudioSource correctSound;
    public AudioSource incorrectSound;
    public AudioSource victorySound;

    [Header("States")]
    PuzzleBaseState currentState;
    public PuzzleSolvedState SolvedState = new PuzzleSolvedState();
    public PuzzleIncorrectState incorrectState = new PuzzleIncorrectState();
    public PuzzlePassiveState passiveState = new PuzzlePassiveState();
    // Start is called before the first frame update
    void Start()
    {
        currentState = passiveState;
        currentState.EnterState(this);
        Debug.Log("Starting");
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdateState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnStateCollision(this, collision);
    }

    public void switchState(PuzzleBaseState state){
        currentState = state;
        state.EnterState(this);
        Debug.Log("Switching");
    }
}

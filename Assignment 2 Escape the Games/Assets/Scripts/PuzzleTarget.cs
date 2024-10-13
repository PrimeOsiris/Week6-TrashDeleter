using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTarget : MonoBehaviour
{
    [Tooltip("The part of obstacle blocking the exit to be deleted once the target has been hit.")]
    public GameObject linkedGate;

    public void SolvingHit()
    {
        Destroy(linkedGate);
    }
}

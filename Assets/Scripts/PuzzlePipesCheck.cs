using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePipesCheck : MonoBehaviour
{
    public UnityEvent onComplete;
    public PuzzlePipeRotate[] pipes;

    public void CheckWin()
    {
        if (IsComplete())
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    [ContextMenu("Win")]
    public void Win()
    {
        onComplete.Invoke();
        Debug.Log("Puzzle Completed!");
    }

    [ContextMenu("Lose")]
    public void Lose()
    {
        Debug.Log("Puzzle Incomplete");
    }

    public bool IsComplete()
    {
        PuzzlePipeRotate.Directions[] allDirections = pipes.Select(item => item.direction).ToArray();

        for (int i = 0; i < allDirections.Length - 1; i++)
        {
            var current = allDirections[i];
            var next = allDirections[i + 1];

            bool rightLeftConnection = current.HasFlag(PuzzlePipeRotate.Directions.right) && next.HasFlag(PuzzlePipeRotate.Directions.left);
            bool upDownConnection = current.HasFlag(PuzzlePipeRotate.Directions.up) && next.HasFlag(PuzzlePipeRotate.Directions.down);
            bool leftRightConnection = current.HasFlag(PuzzlePipeRotate.Directions.left) && next.HasFlag(PuzzlePipeRotate.Directions.right);
            bool downUpConnection = current.HasFlag(PuzzlePipeRotate.Directions.down) && next.HasFlag(PuzzlePipeRotate.Directions.up);

            if (rightLeftConnection)
            {
                allDirections[i] &= ~PuzzlePipeRotate.Directions.right;
                allDirections[i + 1] &= ~PuzzlePipeRotate.Directions.left;
            }

            if (upDownConnection)
            {
                allDirections[i] &= ~PuzzlePipeRotate.Directions.up;
                allDirections[i + 1] &= ~PuzzlePipeRotate.Directions.down;
            }

            if (leftRightConnection)
            {
                allDirections[i] &= ~PuzzlePipeRotate.Directions.left;
                allDirections[i + 1] &= ~PuzzlePipeRotate.Directions.right;
            }

            if (downUpConnection)
            {
                allDirections[i] &= ~PuzzlePipeRotate.Directions.down;
                allDirections[i + 1] &= ~PuzzlePipeRotate.Directions.up;
            }

            if (!rightLeftConnection && !upDownConnection && !leftRightConnection && !downUpConnection)
            {
                Debug.Log($"{pipes[i].name} - {pipes[i + 1].name} couldn't be connected");
                return false;
            }
        }

        return true;
    }
}

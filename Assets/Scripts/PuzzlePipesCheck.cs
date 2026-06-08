using UnityEngine;
using UnityEngine.Events;

public class PuzzlePipesCheck : MonoBehaviour
{
    public UnityEvent onComplete;
    public PuzzlePipeRotate[] pipes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWin()
    {
        if (IsComplete())
        {
            Win();
        }
    }

    [ContextMenu("Win")]
    public void Win()
    {
        onComplete.Invoke();
        Debug.Log("Puzzle Completed!");
    }

    public bool IsComplete()
    {
        for (int i = 1; i < pipes.Length - 1; i++)
        {
            PuzzlePipeRotate previous = pipes[i-1];
            PuzzlePipeRotate current = pipes[i];
            PuzzlePipeRotate next = pipes[i+1];

            bool previousRightLeftConnection = previous.direction.HasFlag(PuzzlePipeRotate.Directions.right) && current.direction.HasFlag(PuzzlePipeRotate.Directions.left);
            bool previousUpDownConnection = previous.direction.HasFlag(PuzzlePipeRotate.Directions.up) && current.direction.HasFlag(PuzzlePipeRotate.Directions.down);
            bool previousLeftRightConnection = previous.direction.HasFlag(PuzzlePipeRotate.Directions.left) && current.direction.HasFlag(PuzzlePipeRotate.Directions.right);
            bool previousDownUpConnection = previous.direction.HasFlag(PuzzlePipeRotate.Directions.down) && current.direction.HasFlag(PuzzlePipeRotate.Directions.up);

            bool nextRightLeftConnection = current.direction.HasFlag(PuzzlePipeRotate.Directions.right) && next.direction.HasFlag(PuzzlePipeRotate.Directions.left);
            bool nextUpDownConnection = current.direction.HasFlag(PuzzlePipeRotate.Directions.up) && next.direction.HasFlag(PuzzlePipeRotate.Directions.down);
            bool nextLeftRightConnection = current.direction.HasFlag(PuzzlePipeRotate.Directions.left) && next.direction.HasFlag(PuzzlePipeRotate.Directions.right);
            bool nextDownUpConnection = current.direction.HasFlag(PuzzlePipeRotate.Directions.down) && next.direction.HasFlag(PuzzlePipeRotate.Directions.up);

            int previousCount = (previousRightLeftConnection ? 1 : 0) + (previousUpDownConnection ? 1 : 0) + (previousLeftRightConnection ? 1 : 0) + (previousDownUpConnection ? 1 : 0);
            int nextCount = (nextRightLeftConnection ? 1 : 0) + (nextUpDownConnection ? 1 : 0) + (nextLeftRightConnection ? 1 : 0) + (nextDownUpConnection ? 1 : 0);

            if (previousCount + nextCount != current.numberOfConnections)
            {
                Debug.Log($"{current.name} and {next.name} are not connected properly.");
                Debug.Log($"Prev Connection Count: {previousCount}");
                Debug.Log($"Next Connection Count: {nextCount}");
                
                return false;
            }
        }

        return true;
    }
}

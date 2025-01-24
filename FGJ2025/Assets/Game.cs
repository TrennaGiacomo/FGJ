using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _bro;

    public DebugCanvas debugCanvas;

    public void HandleScreen(ScreenRoot screen)
    {
        debugCanvas.DebugScreen(screen);

        // Solving logic
        
        // If correct solution
        screen.problem.SolveProblem();

        // Else
        // fail
    }    
}

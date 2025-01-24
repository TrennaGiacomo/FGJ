using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _bro;
    [SerializeField] private ChoiceCreator _choiceCreator;

    public DebugCanvas debugCanvas;

    public void HandleScreen(ScreenRoot screen)
    {
        debugCanvas.DebugScreen(screen);

        // Solving logic
        _bro.StartThinking();

        _choiceCreator.CreateChoices();
        
        // If correct solution
        screen.problem.SolveProblem();

        // Else
        // fail
    }    
}

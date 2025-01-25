using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public UnityEvent OnFinishCurrentScreen = new();

    [SerializeField] private Character _bro;
    [SerializeField] private ChoiceCreator _choiceCreator;

    [SerializeField] private ScreenManager _screenManager;

    public DebugCanvas debugCanvas;

    private ScreenRoot _currentScreen;

    private bool _gameInProgress;
    
    private void Update()
    {
        if (!_gameInProgress && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
            _gameInProgress = true;
        }
    }

    public void StartGame()
    {
        _screenManager.MoveToNextScreen();
    }

    public void EndGame()
    {
        // Do something
    }

    public void HandleScreen(ScreenRoot screen)
    {
        _currentScreen = screen;

        debugCanvas.DebugScreen(screen);

        // Solving logic
        _bro.StartThinking();

        _choiceCreator.CreateChoices();
    }

    public void HandleChoice(ProblemChoice choice)
    {
        var screen = _currentScreen;

        _bro.StopThinking();

        _choiceCreator.ClearChoices();

        StartCoroutine(CheckSolution(screen, choice));
        _currentScreen = null;
    }

    IEnumerator CheckSolution(ScreenRoot screen, ProblemChoice choice)
    {
        if (choice.solutionType == screen.problem.solution)
        {
            // Nice
        }


        // Else
        // fail

        // Do something...
        debugCanvas.debugText.text = "Checking answer...";
        yield return new WaitForSecondsRealtime(3.0f);

        
        debugCanvas.debugText.text = "";

        OnFinishCurrentScreen.Invoke();
    }
}

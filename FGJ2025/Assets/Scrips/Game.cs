using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public UnityEvent OnFinishCurrentScreen = new();

    [SerializeField] private Character _bro;
    [SerializeField] private ChoiceCreator _choiceCreator;

    [SerializeField] private ScreenManager _screenManager;

    public DebugCanvas debugCanvas;

    private ScreenRoot _currentScreen;

    private bool _gameInProgress;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        StartGame();
        _gameInProgress = true;
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

        _currentScreen.OnComplete.AddListener(OnFinishCurrentScreen.Invoke);
        _currentScreen.StartScreen();
    }

    public void PlayEndSequence()
    {
        SceneManager.LoadScene("EndSequence");
    }
}

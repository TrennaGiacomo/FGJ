using UnityEngine;
using UnityEngine.Events;

public class ScreenRoot : MonoBehaviour
{
    public Bounds bounds;
    public UnityEvent OnComplete { get; } = new();

    [SerializeField] private ScreenLogic _screenLogic;

    public void StartScreen()
    {
        _screenLogic.OnComplete.AddListener(OnLogicComplete);
        _screenLogic.isActive = true;
        _screenLogic.PlayLogic();
    }

    private void OnLogicComplete()
    {
        OnComplete.Invoke();
        _screenLogic.isActive = false;
        _screenLogic.CleanUp();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}

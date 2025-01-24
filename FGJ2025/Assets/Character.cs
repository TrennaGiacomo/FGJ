using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject _thoughtBubble;

    public void StartThinking()
    {
        _thoughtBubble.SetActive(true);
    }

    public void StopThinking()
    {
        _thoughtBubble.SetActive(false);
    }

    public void StartWalking()
    {

    }

    public void StopWalking()
    {

    }
}

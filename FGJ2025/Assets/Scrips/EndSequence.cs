using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSequence : MonoBehaviour
{
    public BridgeAnimation bridgeAnimation;
    public Character bro;
    public HealedCharacter healedBro;

    public Animator animator;

    public FadeToBlack fade;

    void Start()
    {
        bridgeAnimation.Animate(onFinish: OnBridgeBuilt);
    }

    void OnBridgeBuilt()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2);

        bool finished = false;
        bro.SaySomething("I'm too scared", onFinish: () =>
        {
            finished = true;
        });

        while (!finished)
            yield return null;

        yield return new WaitForSeconds(3);

        PlayAnimation();
    }

    void PlayAnimation()
    {
        animator.SetBool("PlaySequence", true);
    }

    public void FadeToBlackAndLoadMainMenu()
    {
        fade.Fade(onFinish: () => SceneManager.LoadScene("MainMenu"));
    }

    public void WalkBro()
    {
        bro.StartWalking();
    }

    public void StopWalkBro()
    {
        bro.StopWalking();
    }

    public void WalkHealedBro()
    {
        healedBro.StartWalking();
    }

    public void StopWalkHealedBro()
    {
        healedBro.StopWalking();
    }
}

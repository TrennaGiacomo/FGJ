using System;
using System.Collections;
using UnityEngine;

public class BridgeAnimation : MonoBehaviour
{
    public Material[] materials;
    public Renderer renderer;

    public void Animate(Action onFinish)
    {
        StartCoroutine(AnimateCoroutine(onFinish));
    }

    private IEnumerator AnimateCoroutine(Action onFinish)
    {
        const float interval = 0.15f;

        int index = 0;
        while (index < materials.Length)
        {
            renderer.material = materials[index];
            
            yield return new WaitForSecondsRealtime(interval);
            index++;            
        }

        onFinish.Invoke();
    }
}

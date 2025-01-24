using UnityEngine;

public class ScreenRoot : MonoBehaviour
{
    public Bounds bounds;

    public Problem problem;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}

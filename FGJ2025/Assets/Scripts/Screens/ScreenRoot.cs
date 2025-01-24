using UnityEngine;

public class ScreenRoot : MonoBehaviour
{
    public Bounds bounds;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}

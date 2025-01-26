using UnityEngine;

public class DontDestroyOnLoadMusic : MonoBehaviour
{
    public static AudioSource musicSource;

    void Awake()
    {
        DontDestroyOnLoad(this);

        musicSource = GetComponent<AudioSource>();
    }
}

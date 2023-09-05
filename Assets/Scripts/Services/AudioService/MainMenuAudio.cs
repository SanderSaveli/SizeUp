using UnityEngine;

[CreateAssetMenu(fileName = "Main Menu Audio", menuName = "Audio/ new Main Menu Audio")]
public class MainMenuAudio : ScriptableObject 
{
    [Header("Audio")]
    public AudioClip mainTheme;

    [Space]
    [Header("Sounds")]
    public AudioClip GameStart;
    public AudioClip GameEnd;
    public AudioClip ButtonClick;
}

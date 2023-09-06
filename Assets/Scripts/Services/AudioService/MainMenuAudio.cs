using UnityEngine;

[CreateAssetMenu(fileName = "Main Menu Audio", menuName = "Audio/ new Main Menu Audio")]
public class MainMenuAudio : ScriptableObject 
{
    [Header("Audio")]
    [SerializeField] private AudioClip _mainTheme;

    [Space]
    [Header("Sounds")]
    [SerializeField] private AudioClip _gameStart;
    [SerializeField] private AudioClip _gameEnd;
    [SerializeField] private AudioClip _buttonClick;

    public AudioClip mainTheme => _mainTheme;
    public AudioClip gameStart => _gameStart;
    public AudioClip gameEnd => _gameEnd;
    public AudioClip buttonClick => _buttonClick;
}

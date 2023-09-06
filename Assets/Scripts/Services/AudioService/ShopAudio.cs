using UnityEngine;

[CreateAssetMenu(fileName = "Shop Audio", menuName = "Audio/new Shop Audio")]
public class ShopAudio : ScriptableObject
{
    [Header("Audio")]
    [SerializeField] private AudioClip _mainShopTheme;

    [Space]
    [Header("Sounds")]
    [SerializeField] private AudioClip _buy;
    [SerializeField] private AudioClip _selection;
    [SerializeField] private AudioClip _changeTongue;
    [SerializeField] private AudioClip _shopOpen;
    [SerializeField] private AudioClip _shopClosed;

    public AudioClip mainShopTheme => _mainShopTheme;
    public AudioClip buy => _buy;
    public AudioClip selection => _selection;
    public AudioClip changeTongue => _changeTongue;
    public AudioClip shopOpen => _shopOpen;
    public AudioClip shopClosed => _shopClosed;
}

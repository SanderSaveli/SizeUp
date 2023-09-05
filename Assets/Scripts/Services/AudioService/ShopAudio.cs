using UnityEngine;

[CreateAssetMenu(fileName = "Shop Audio", menuName = "Audio/new Shop Audio")]
public class ShopAudio : ScriptableObject
{
    [Header("Audio")]
    public AudioClip mainShopTheme;

    [Space]
    [Header("Sounds")]
    public AudioClip buy;
    public AudioClip selection;
    public AudioClip changeTongue;
    public AudioClip shopOpen;
    public AudioClip shopClosed;
}

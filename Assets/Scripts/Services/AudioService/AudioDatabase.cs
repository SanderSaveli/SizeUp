using UnityEngine;
namespace Services.Audio 
{ 
    [CreateAssetMenu(fileName = "Audio Database", menuName = "Audio/new Audio Database")]
    public class AudioDatabase : ScriptableObject
    {
        public MainMenuAudio menuAudio;
        public ShopAudio shopAudio;
    }
}

using UnityEngine;
namespace Services.Audio 
{ 
    [CreateAssetMenu(fileName = "SuccsessAudio", menuName = "Audio/new SuccsessAudio")]
    public class SuccessAudio : ScriptableObject
    {
        [SerializeField] private AudioClip _one;
        [SerializeField] private AudioClip _two;
        [SerializeField] private AudioClip _three;
        [SerializeField] private AudioClip _four;
        [SerializeField] private AudioClip _five;
        [SerializeField] private AudioClip _six;
        [SerializeField] private AudioClip _seven;

        public AudioClip one => _one;
        public AudioClip two => _two;
        public AudioClip three => _three;
        public AudioClip four => _four;
        public AudioClip five => _five;
        public AudioClip six => _six;
        public AudioClip seven => _seven;
    }

}



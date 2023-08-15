using UnityEngine;

namespace Services.Economic
{
    [CreateAssetMenu(fileName = "Figure", menuName = "Figures/new Figure")]
    public class Figure : ScriptableObject, ISold
    {
        [field: SerializeField] public int price { get; private set; }
        [field: SerializeField] public Sprite potrait { get; private set; }
        [field: SerializeField] public GameObject figureObject { get; private set; }
    }

}

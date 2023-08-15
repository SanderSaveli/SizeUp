using System.Collections.Generic;
using UnityEngine;

namespace Services.Economic 
{
    [CreateAssetMenu(fileName = "Figure database", menuName = "Figures/new Figure database")]
    public class FigureDatabase : ScriptableObject
    {
        [field: SerializeField] public List<Figure> figures { get; private set; }
    }
}

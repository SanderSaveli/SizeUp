using Services.Economic;
using System.Collections.Generic;
using UnityEngine;

namespace ViewElements
{
    [CreateAssetMenu(fileName = "Theme Database", menuName = "Themes/new Theme Database")]
    public class ThemeDatabase : ScriptableObject
    {
        [field: SerializeField] public List<Theme> themes { get; private set; }
    }
}


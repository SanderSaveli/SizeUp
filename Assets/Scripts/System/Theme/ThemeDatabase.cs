using System.Collections.Generic;
using UnityEngine;

namespace ViewElements
{
    [CreateAssetMenu(fileName = "Theme Database", menuName = "Themes/new Theme Database")]
    public class ThemeDatabase : ScriptableObject
    {
        public List<Theme> themes = new List<Theme>();

        private void Awake()
        {
            Debug.Log(themes);
        }
    }
}


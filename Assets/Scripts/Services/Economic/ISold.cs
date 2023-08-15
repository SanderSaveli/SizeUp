using UnityEngine;

namespace Services.Economic
{
    public interface ISold
    {
        public int price { get; }

        public Sprite potrait { get; }
    }
}


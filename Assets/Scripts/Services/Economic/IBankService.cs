namespace Services.Economic
{
    public interface IBankService : IService
    {
        public delegate void ValueChange(int value);
        public event ValueChange OnValueChange;
        public int value { get; }
        public bool TrySpendValue(int cost);
        public void AddValue(int value);
    }
}

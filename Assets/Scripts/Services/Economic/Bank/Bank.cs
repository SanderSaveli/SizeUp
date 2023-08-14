using Services.StorageService;

namespace Services.Economic
{
    public class Bank : IBankService
    {
        public event IBankService.ValueChange OnValueChange;
        public int value { get => _value ; private set 
            {
                _value = value;
                SaveValue();
                OnValueChange?.Invoke(_value);
            }}
        private int _value;
        private IStoregeService _storegeService;
        private const string _loadKey = "Value";


        public void AddValue(int value)
        {
            this.value += value;
        }

        public void Initialize()
        {
            _storegeService = ServiceLockator.instance.GetService<IStoregeService>();
            LoadValue();
        }

        public void Shutdown()
        {   }

        public bool TrySpendValue(int cost)
        {
            if(value - cost > 0) 
            {
                value -= cost;
                return true;
            }
            else 
            {
                return false;
            }
        }

        private void LoadValue() 
        {
            _value = _storegeService.Load<int>(_loadKey);
        }
        private void SaveValue() 
        {
            _storegeService.Save(_loadKey, _value);
        }
    }
}


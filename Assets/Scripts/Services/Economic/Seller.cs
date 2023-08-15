using Services.StorageService;
using System;
using System.Collections.Generic;

namespace Services.Economic
{
    public class Seller<T> where T : ISold
    {
        public delegate void NewItemSelected(T item);
        public event NewItemSelected OnNewItemSelected;

        public T selectedItem
        {
            get => _selectedItem;
            private set
            {
                _selectedItem = value;
                OnNewItemSelected?.Invoke(value);
            }
        }
        private T _selectedItem;

        public IReadOnlyDictionary<T, ItemStatus> allItems { get => _allItems; }
        private Dictionary<T, ItemStatus> _allItems;

        private IStoregeService _storegeService;
        private IBankService _bankService;
        private readonly string _saveKey;

        public Seller(List<T> items, IStoregeService storegeService, IBankService bank, string saveKey)
        {
            _storegeService = storegeService;
            _saveKey = saveKey;
            IniItems(items);
            _selectedItem = FindSelectedItem();
        }

        private T FindSelectedItem()
        {
            foreach (T item in _allItems.Keys)
            {
                if (_allItems.TryGetValue(item, out ItemStatus status))
                {
                    if (status == ItemStatus.Selected)
                    {
                        return item;
                    }
                }
            }
            throw new NotImplementedException($"There is no seleckted {typeof(T)}!");
        }

        public bool OpenItem(T item)
        {
            if (_allItems.ContainsKey(item))
            {
                if (_allItems[item] == ItemStatus.Close)
                {
                    if (_bankService.TrySpendValue(item.price))
                    {
                        _allItems[item] = ItemStatus.Open;
                        SaveCurrentStatuses();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool SelectItem(T item)
        {
            if (_allItems.ContainsKey(item))
            {
                if (_allItems[item] == ItemStatus.Open)
                {
                    _allItems[selectedItem] = ItemStatus.Open;
                    selectedItem = item;
                    _allItems[item] = ItemStatus.Selected;
                    SaveCurrentStatuses();
                    return true;
                }
            }
            return false;
        }

        private bool LoadItemStatus(out List<ItemStatus> itemStatuses)
        {
            itemStatuses = _storegeService.Load<List<ItemStatus>>(_saveKey);
            if (itemStatuses == null || itemStatuses.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void SaveCurrentStatuses()
        {
            List<ItemStatus> statuses = new();
            foreach (T item in allItems.Keys)
            {
                statuses.Add(allItems[item]);
            }
            _storegeService.Save(_saveKey, statuses);
        }

        private void IniItems(List<T> items)
        {
            if (LoadItemStatus(out List<ItemStatus> itemStatuses) &&
                itemStatuses.Count == items.Count)
            {
                DefaultThemeIni(items, itemStatuses);
            }
            else
            {
                CreateNewStatusesAndIni(items, itemStatuses);
            }
        }

        private void DefaultThemeIni(List<T> items, List<ItemStatus> themeStatuses)
        {
            _allItems = new Dictionary<T, ItemStatus>();
            int i = 0;
            foreach (T item in items)
            {
                _allItems.Add(item, themeStatuses[i++]);
            }
        }

        private void CreateNewStatusesAndIni(List<T> items, List<ItemStatus> themeStatuses)
        {
            _allItems = new Dictionary<T, ItemStatus>();
            foreach (T item in items)
            {
                _allItems.Add(item, ItemStatus.Close);
            }
            _allItems[items[0]] = ItemStatus.Selected;
            SaveCurrentStatuses();
        }
    }
}


using System;

namespace Services.StorageService
{
    public class NullStorageService : IStoregeService
    {
        public void Initialize()
        { }

        public void CallbackLoad<T>(string key, Action<T> callback)
        { }

        public void Save(string key, object data, Action<bool> callback = null)
        { }

        public void Shutdown()
        { }

        public T Load<T>(string key)
        {
            return default(T);
        }

        public bool HasKey(string key)
        {
            return false;
        }
    }
}


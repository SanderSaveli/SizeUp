using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.InputSystem;

namespace Services.StorageService
{
    public class JSONToFileStorageService : IStoregeService
    {
        public void Save(string key, object data, Action<bool> callback = null)
        {
            string path = BuildPath(key);
            string json = JsonConvert.SerializeObject(data); 

            using (var file = new StreamWriter(path))
            {
                file.Write(json);
            }

            callback?.Invoke(true);
        }
        public void CallbackLoad<T>(string key, Action<T> callback)
        {
            callback.Invoke(Load<T>(key));
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }

        public void Initialize()
        {   }

        public void Shutdown()
        {   }

        public T Load<T>(string key)
        {
            string path = BuildPath(key);
            try 
            {
                using (var file = new StreamReader(path))
                {
                    string json = file.ReadToEnd();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    if (data == null)
                    {
                        return LogAndretirnDefaultValue<T>();
                    }
                    return data;
                }
            }
            catch (FileNotFoundException) 
            {
                return LogAndretirnDefaultValue<T>();
            }
        }

        public bool HasKey(string key) 
        {
            string path = BuildPath(key);
            try
            {
                using (var file = new StreamReader(path))
                {
                    string json = file.ReadToEnd();
                    if(json != null) 
                    {
                        return true;
                    }
                    else 
                    { 
                        return false;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        private T LogAndretirnDefaultValue<T>() 
        {
            Debug.LogWarning("Failed to load data");
            return default(T);
        }
    }
}

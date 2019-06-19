namespace Utilities
{       
    using UnityEngine;
    
    using JetBrains.Annotations;

    #if ODIN_INSPECTOR
    using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour; 
    #endif

    /// <summary>Type of Singleton that makes sure there's an Instance (If there isn't one it will Instantiate an Instance of the script). </summary>
    /// <typeparam name="T">Type of the EnsuredSingleton</typeparam>
    public abstract class EnsuredSingleton<T> : MonoBehaviour where T : EnsuredSingleton<T>
    //Why don't virtual statics exist?....
    //If anyone knows how I can make this Inherit from Singleton it would be much appreciated if you created a Request or contact me directly.
    //I'm just here waiting for Interfaces to have default implementations..
    {
        private static readonly object obj = new object();
        
        private static T _instance = null;
        
        [PublicAPI]
        public static T Instance
        {
            get
            {
                if (_applicationIsQuitting) { return null; }

                lock (obj)
                {
                    if (_instance != null) { return _instance; }
                    
                    GameObject _singletonGameObject = new GameObject{name = $"{typeof(T)} singleton"};
                    _instance = _singletonGameObject.AddComponent<T>();
                    
                    return _instance;
                }
            }
                    
            protected set => _instance = value;
        }
        
        [PublicAPI]
        public static bool InstanceExists => (Instance != null);
        
        private static bool _applicationIsQuitting = false;

        /// <summary> OnEnable method to associate EnsuredSingleton with Instance </summary>
        protected virtual void OnEnable()
        {
            if (InstanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = (T)this;
            }
        }

        /// <summary> OnDestroy method to clear EnsuredSingleton association </summary>
        private void OnDestroy()
        {
            _applicationIsQuitting = true;
            
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}
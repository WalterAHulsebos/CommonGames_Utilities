namespace Utilities.CGTK
{
    using UnityEngine;
    
    using Object = UnityEngine.Object;
    
    public static partial class CGDebug
    {
        public static void Log(object message)
        {
            #if UNITY_EDITOR
            Debug.Log(message);
            #elif DEBUGBUILD
            Debug.Log(message);
            #endif
        }
    
        public static void Log(object message, Object context)
        {
            #if UNITY_EDITOR
            Debug.Log(message, context);
            #elif DEBUGBUILD
            Debug.Log(message, context);
            #endif
        }
    
        public static void LogFormat(string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogFormat(format, args);
            #elif DEBUGBUILD
            Debug.LogFormat(format, args);
            #endif
        }
    
        public static void LogFormat(Object context, string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogFormat(context, format, args);
            #elif DEBUGBUILD
            Debug.LogFormat(context, format, args);
            #endif
        }
    
        public static void LogAssertion(Object message)
        {
            #if UNITY_EDITOR
            Debug.LogAssertion(message);
            #elif DEBUGBUILD
            Debug.LogAssertion(message);
            #endif
        }
    
        public static void LogAssertion(Object message, Object context)
        {
            #if UNITY_EDITOR
            Debug.LogAssertion(message, context);
            #elif DEBUGBUILD
            Debug.LogAssertion(message, context);
            #endif
        }
    
        public static void LogAssertionFormat(string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogAssertionFormat(format, args);
            #elif DEBUGBUILD
            Debug.LogAssertionFormat(format, args);
            #endif
        }
    
        public static void LogAssertionFormat(Object context, string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogAssertionFormat(context, format, args);
            #elif DEBUGBUILD
            Debug.LogAssertionFormat(context, format, args);
            #endif
        }
    
        public static void LogError(object message)
        {
            #if UNITY_EDITOR
            Debug.LogError(message);
            #elif DEBUGBUILD
            Debug.LogError(message);
            #endif
        }
    
        public static void LogError(object message, Object context)
        {
            #if UNITY_EDITOR
            Debug.LogError(message, context);
            #elif DEBUGBUILD
            Debug.LogError(message, context);
            #endif
        }
    
        public static void LogErrorFormat(string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogErrorFormat(format, args);
            #elif DEBUGBUILD
            Debug.LogErrorFormat(format, args);
            #endif
        }
    
        public static void LogErrorFormat(Object context, string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogErrorFormat(context, format, args);
            #elif DEBUGBUILD
            Debug.LogErrorFormat(context, format, args);
            #endif
        }
    
        public static void LogWarning(object message)
        {
            #if UNITY_EDITOR
            Debug.LogWarning(message);
            #elif DEBUGBUILD
            Debug.LogWarning(message);
            #endif
        }
    
        public static void LogWarning(object message, Object context)
        {
            #if UNITY_EDITOR
            Debug.LogWarning(message, context);
            #elif DEBUGBUILD
            Debug.LogWarning(message, context);
            #endif
        }
    
        public static void LogWarningFormat(string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogWarningFormat(format, args);
            #elif DEBUGBUILD
            Debug.LogWarningFormat(format, args);
            #endif
        }
    
        public static void LogWarningFormat(Object context, string format, params object[] args)
        {
            #if UNITY_EDITOR
            Debug.LogWarningFormat(context, format, args);
            #elif DEBUGBUILD
            Debug.LogWarningFormat(context, format, args);
            #endif
        }
    }
}
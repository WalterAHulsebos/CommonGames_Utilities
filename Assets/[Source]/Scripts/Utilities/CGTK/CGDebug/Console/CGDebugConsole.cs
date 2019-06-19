using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

using UnityEngine;

using Utilities;
using Utilities.Extensions;

using JetBrains.Annotations;

namespace Utilities.CGTK
{
    public class CGDebugConsole : MonoBehaviour
    {
        #region Variables
        
        private readonly List<Log> logs = new List<Log>();
        private readonly ConcurrentQueue<Log> queuedLogs = new ConcurrentQueue<Log>();
        
        ///<summary> The size of a normal debug text block. </summary>
        private const int TEXTBLOCK_MARGINS = 22;
        
        ///<summary> The max string length supported by UnityEngine.GUILayout.Label </summary>
        private const int MAX_MESSAGE_LENGTH = 16382;

        private static readonly Dictionary<LogType, Color> LogTypeColors = new Dictionary<LogType, Color>
        {
            { LogType.Assert, Color.white },
            { LogType.Error, Color.red },
            { LogType.Exception, Color.red },
            { LogType.Log, Color.white },
            { LogType.Warning, Color.yellow },
        };

        private static readonly Dictionary<LogType, bool> LogTypeFilters = new Dictionary<LogType, bool>
        {
            { LogType.Assert, true },
            { LogType.Error, true },
            { LogType.Exception, true },
            { LogType.Log, true },
            { LogType.Warning, true },
        };

        ///<summary> Container for log details. </summary>
        private struct Log
        {
            public int count;
            public string message;
            public string stackTrace;
            public LogType type;

            public Log(int count, string message, string stackTrace, LogType type)
            {
                this.count = count;
                this.message = message;
                this.stackTrace = stackTrace;
                this.type = type;
            }
    
            /// <summary> Check if two Logs are the same. </summary>
            public bool Equals(Log log)
                => ((message == log.message) && (stackTrace == log.stackTrace) && (type == log.type));
    
            ///<summary> Return a truncated message if it exceeds the max message length. </summary>
            public string TruncatedMessage
            {
                get
                {
                    if (string.IsNullOrEmpty(message)) return message;
        
                    return message.Length <= MAX_MESSAGE_LENGTH 
                        ? message 
                        : message.Substring(0, MAX_MESSAGE_LENGTH);   
                }
            }
            
        }

        #endregion

        #region Methods
        
        private void OnDisable()
        {
            Application.logMessageReceivedThreaded -= EnqueueNewLog;
        }
        private void OnEnable()
        {
            Application.logMessageReceivedThreaded += EnqueueNewLog;
        }
        
        private void Update()
        {
            //TODO: Walter - Make it so it only works when the Console is actually activated.
            
            UpdateQueuedLogs();
        }

        
        private void UpdateQueuedLogs()
        {
            while(queuedLogs.TryDequeue(out Log _log))
            {
                ProcessLogItem(_log);
            }
        }
        
        private void EnqueueNewLog(string message, string stackTrace, LogType type)
        {            
            queuedLogs.Enqueue
            (
                new Log
                {
                    count = 1,
                    message = message,
                    stackTrace = stackTrace,
                    type = type,
                }
            );
        }

        private void ProcessLogItem(Log log)
        {
            bool _isDuplicateOfLastLog = LastLog.HasValue && log.Equals(LastLog.Value);

            if(_isDuplicateOfLastLog)
            {
                //Replace previous log with incremented count instead of adding a new one.
                log.count = LastLog.Value.count + 1;
                logs[logs.Count-1] = log;
            }
            else
            {
                logs.Add(log);
            }
        }

        [CanBeNull]
        private Log? LastLog
        {
            get
            {
                if(logs.Count == 0) return null;

                return logs.Last();    
            }
        }
        
        #endregion
    }
}
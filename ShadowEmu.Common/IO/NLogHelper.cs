using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.IO
{
    public static class NLogHelper
    {
        public static string LogFormatConsole = "|${level:uppercase=true}|${logger:shortName=true}|${message}";
        public static string LogFormatFile = "[${level}] <${date:format=G}> ${message}";
        public static readonly string LogFilePath = "/logs/";

        public static void DefineLogProfile(bool activefileLog, bool activeconsoleLog)
        {
            LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
    
            ColoredConsoleTarget target = new ColoredConsoleTarget
            {
                Layout = NLogHelper.LogFormatConsole
            };
            FileTarget target2 = new FileTarget
            {
                FileName = "${basedir}" + NLogHelper.LogFilePath + "log_${date:format=dd-MM-yyyy}.txt",
                Layout = NLogHelper.LogFormatFile
            };
            FileTarget target3 = new FileTarget
            {
                FileName = "${basedir}" + NLogHelper.LogFilePath + "error_${date:format=dd-MM-yyyy}.txt",
                Layout = "-------------${level} at ${date:format=G}------------- ${newline} ${callsite} -> ${newline}\t${message} ${newline}-------------${level} at ${date:format=G}------------- ${newline}"
            };
            if (activefileLog)
            {
                loggingConfiguration.AddTarget("file", target2);
                loggingConfiguration.AddTarget("fileErrors", target3);
            }
            if (activeconsoleLog)
            {
                loggingConfiguration.AddTarget("console", target);
            }
            LogLevel debug = LogLevel.Debug;
            if (activeconsoleLog)
            {
                LoggingRule loggingRule = new LoggingRule("*", debug, target);
                loggingConfiguration.LoggingRules.Add(loggingRule);
            }
            if (activefileLog)
            {
                LoggingRule loggingRule = new LoggingRule("*", debug, target2);
                loggingRule.DisableLoggingForLevel(LogLevel.Fatal);
                loggingRule.DisableLoggingForLevel(LogLevel.Error);
                loggingConfiguration.LoggingRules.Add(loggingRule);
                LoggingRule item = new LoggingRule("*", LogLevel.Warn, target3);
                loggingConfiguration.LoggingRules.Add(item);
            }
            
            LogManager.Configuration = loggingConfiguration;
        }

        public static void EnableLogging()
        {
            LogManager.EnableLogging();
        }

        public static void DisableLogging()
        {
            LogManager.DisableLogging();
        }
    }
}

﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public static class Log4NetLoggerFactoryExtensions
    {
        private static string CheckFilepath(string FilePath)
        {
            //if (!(FilePath != null && FilePath.Length > 0))
            if (FilePath is not { Length: > 0 }) 
                throw new ArgumentException("Указан некорректный путь к файлу", nameof(FilePath));
            
            if (Path.IsPathRooted(FilePath)) return FilePath;

            var assembly = Assembly.GetEntryAssembly();
            var dir = Path.GetDirectoryName(assembly.Location);
            return Path.Combine(dir!, FilePath);
        }

        public static ILoggerFactory AddLog4Net(this ILoggerFactory Factory, string ConfigurationFile = "Log4Net.config")
        {

            Factory.AddProvider(new Log4NetLoggerProvider(ConfigurationFile));
            return Factory;
        }
    }
}

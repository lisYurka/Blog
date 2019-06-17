using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Logging
{
    public static class FileLogExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory loggerFactory , string path)
        {
            loggerFactory.AddProvider(new FileLogProvider(path));
            return loggerFactory;
        }
    }
}

using Serilog;
using System;

namespace Paymentsense.Coding.Challenge.Api.Services.Logging
{
    public static class LogManager
    {
        public static ILogger GetLogger<TContextType>()
        {
            return GetLogger(typeof(TContextType));
        }

        public static ILogger GetLogger(Type type)
        {
            return Log.Logger.ForContext(type);
        }
    }
}

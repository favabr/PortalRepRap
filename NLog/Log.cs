using NLog;

namespace PortalRepRap.Framework.NLog
{
    public class Log
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static Logger Logger
        {
            get
            {
                return _logger;
            }
        }
    }
}

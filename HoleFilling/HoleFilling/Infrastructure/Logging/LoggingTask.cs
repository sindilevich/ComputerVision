using System.Diagnostics;
using log4net;

namespace HoleFilling.Infrastructure.Logging
{
	internal class LoggingTask
	{
		private readonly ILog m_logger;
		private readonly Stopwatch m_stopwatch;
		private string m_actionMessage;

		protected LoggingTask(ILog logger, string actionMessage)
		{
			m_logger = logger;
			m_actionMessage = actionMessage;
			m_stopwatch = new Stopwatch();
			m_logger.Info($"Starting {actionMessage}");
			m_stopwatch.Start();
		}

		public static LoggingTask Start(LoggingTaskType taskType, string actionMessage)
		{
			ILog logger = LogManager.GetLogger(taskType.ToString());

			return new LoggingTask(logger, actionMessage);
		}

		public void Finish()
		{
			m_stopwatch.Stop();
			m_logger.Info($"Finished {m_actionMessage} in {m_stopwatch.Elapsed:c}");
			m_actionMessage = string.Empty;
		}
	}
}
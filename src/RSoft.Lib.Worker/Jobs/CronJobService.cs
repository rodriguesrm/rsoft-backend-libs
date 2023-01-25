using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RSoft.Lib.Worker.Jobs
{

    /// <summary>
    /// Abstract object of jobs to be executed
    /// </summary>
    public abstract class CronJobService<TLog> : IHostedService, IDisposable
        where TLog : class
    {

        #region Local objects/variables

        private System.Timers.Timer? _timer;
        private readonly CronExpression _expression;
        private readonly TimeZoneInfo _timeZoneInfo;
        private readonly bool _runImmediately;
        private readonly ILogger<TLog>? _logger;

        /// <summary>
        /// Execution counter value
        /// </summary>
        protected int _executionCounter;

        #endregion

        #region Construtors

        /// <summary>
        /// Create a new object instance
        /// </summary>
        /// <param name="cronExpression">Schedule cron expression</param>
        /// <param name="timeZoneInfo">Timezone information</param>
        /// <param name="logger">Logger object instance</param>
        protected CronJobService(string cronExpression, TimeZoneInfo timeZoneInfo, ILogger<TLog>? logger) 
            : this(cronExpression, timeZoneInfo, logger, false) { }

        /// <summary>
        /// Create a new object instance
        /// </summary>
        /// <param name="cronExpression">Schedule cron expression</param>
        /// <param name="timeZoneInfo">Timezone information</param>
        /// <param name="logger">Logger object instance</param>
        /// <param name="runImmediately">Indicates that a run should start immediately</param>
        protected CronJobService(string cronExpression, TimeZoneInfo timeZoneInfo, ILogger<TLog>? logger, bool runImmediately)
        {
            _expression = CronExpression.Parse(cronExpression);
            _timeZoneInfo = timeZoneInfo;
            _logger = logger;
            _runImmediately = runImmediately;
            _executionCounter = 0;
        }

        #endregion

        #region Local methods

        /// <summary>
        /// Schedules the activity for the next run
        /// </summary>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        protected virtual async Task ScheduleJob(CancellationToken cancellationToken)
        {

            DateTimeOffset? next = _expression.GetNextOccurrence(DateTimeOffset.Now, _timeZoneInfo);
            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                _timer = new System.Timers.Timer(delay.TotalMilliseconds);
                _timer.Elapsed += async (sender, args) =>
                {

                    // reset and dispose timer
                    _timer.Dispose();
                    _timer = null;

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        _executionCounter++;
                        await DoWork(cancellationToken);
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await ScheduleJob(cancellationToken);    // reschedule next
                    }
                };
                _timer.Start();
            }
            await Task.CompletedTask;
        }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            if (_runImmediately)
            {
                _executionCounter++;
                await DoWork(cancellationToken);
            }
            await ScheduleJob(cancellationToken);
        }

        /// <summary>
        /// Run the scheduled task
        /// </summary>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        public abstract Task DoWork(CancellationToken cancellationToken);

        ///<inheritdoc/>
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger?.LogInformation($"{nameof(TLog)}: stopped");
            _timer?.Stop();
            await Task.CompletedTask;
        }

        ///<inheritdoc/>
        public virtual void Dispose()
            => _timer?.Dispose();

        #endregion
    }


}

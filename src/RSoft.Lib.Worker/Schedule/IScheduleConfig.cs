namespace RSoft.Lib.Worker.Schedule
{

    /// <summary>
    /// Schedule settings interface
    /// </summary>
    /// <typeparam name="TJob">Job Type to be executed</typeparam>
    public interface IScheduleConfig<TJob>
    {

        /// <summary>
        /// Schedule cron expression
        /// </summary>
        string? CronExpression { get; set; }

        /// <summary>
        /// Timezone information
        /// </summary>
        TimeZoneInfo? TimeZoneInfo { get; set; }

    }

}

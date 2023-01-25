namespace RSoft.Lib.Worker.Schedule
{

    /// <summary>
    /// Schedule settings object
    /// </summary>
    /// <typeparam name="TJob">Job Type to be executed</typeparam>
    public class ScheduleConfig<TJob> : IScheduleConfig<TJob>
    {

        ///<inheritdoc/>
        public string? CronExpression { get; set; }

        ///<inheritdoc/>
        public TimeZoneInfo? TimeZoneInfo { get; set; }

    }


}

using EducationPlatform.Domain.Extensions;

namespace EducationPlatform.Domain
{
    public class TimeRange
    {
        public TimeOnly Start { get; }
        public TimeOnly End { get; }
        public TimeRange(TimeOnly start, TimeOnly end)
        {
            Start = start;
            End = end.IsGreaterThan(start);
        }
    }
}

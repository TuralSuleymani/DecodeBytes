using EducationPlatform.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Domain.Extensions;
namespace EducationPlatform.UnitTests
{
    public class TimeRangeTests
    {
        [Fact]
        public void ctor_WhenEndIsLessThanStart_ThrowsArgumentException()
        {
            // Arrange
            var start = new TimeOnly(10, 0);
            var end = new TimeOnly(9, 0);

            // Act
            Action act = () => new TimeRange(start, end);

            // Assert
            act.Should().Throw<ValidationException>().WithMessage($"{end} should be greater than {start}");
        }
    }
}

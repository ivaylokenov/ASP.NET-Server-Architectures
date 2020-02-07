using DefaultTemplate.Application.Common.Interfaces;
using System;

namespace DefaultTemplate.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

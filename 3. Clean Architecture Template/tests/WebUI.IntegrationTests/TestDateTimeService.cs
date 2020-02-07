using DefaultTemplate.Application.Common.Interfaces;
using System;

namespace DefaultTemplate.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

using System;
using service.Interfaces;

namespace service.Services
{
    public class UtcTimeProvider : ITimeProvider
    {
        public DateTime CurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
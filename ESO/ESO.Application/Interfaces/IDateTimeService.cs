using System;
using System.Collections.Generic;
using System.Text;

namespace ESO.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}

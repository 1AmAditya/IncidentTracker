using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentTracker.Common.Enum
{
    public class Enums
    {

        public enum SeverityEnum
        {
            High = 1,
            Medium,
            Low
        }

        public enum StatusEnum
        {
            Created = 1,
            Inprogess,
            Closed
        }
    }
}

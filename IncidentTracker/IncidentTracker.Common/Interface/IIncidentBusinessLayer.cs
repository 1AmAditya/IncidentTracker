using IncidentTracker.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static IncidentTracker.Common.Enum.Enums;

namespace IncidentTracker.Common.Interface
{
    public interface IIncidentBusinessLayer
    {
        IncidentDataModel IncidentInsertUpdate(IncidentDataModel incidentDataModel);
        bool IncidentDelete(int Id);

        IncidentDataModel IncidentSeverityUpdate(int Id, SeverityEnum severityEnum);
        IncidentDataModel IncidentStatusUpdate(int Id, StatusEnum statusEnum);
    }
}

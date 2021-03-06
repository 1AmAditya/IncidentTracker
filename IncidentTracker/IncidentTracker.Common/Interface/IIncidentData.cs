using IncidentTracker.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentTracker.Common.Interface
{
    public interface IIncidentData
    {
        IncidentDataModel CreateAndUpdate(IncidentDataModel incidentData);

        List<IncidentDataModel> GetIncidentDatas { get; }

        bool Delete(int id);
    }
}

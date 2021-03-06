using IncidentTracker.Common.Interface;
using IncidentTracker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IncidentTracker.Common.Enum.Enums;

namespace IncidentTracker.BusinessLayer
{
    public class IncidentBusinessLayer : IIncidentBusinessLayer
    {
        IIncidentData incidentData;
        public IncidentBusinessLayer( IIncidentData incidentData)
        {
            this.incidentData = incidentData;
        }

        public IncidentDataModel IncidentInsertUpdate(IncidentDataModel incidentDataModel)
        {

            return incidentData.CreateAndUpdate(incidentDataModel);
        }

        public IncidentDataModel IncidentStatusUpdate(int Id , StatusEnum statusEnum)
        {
            IncidentDataModel item = incidentData.GetIncidentDatas.Where(x => x.IncidentID == Id).FirstOrDefault();
            if(item == null)
            {
                return item;
            }
            else
            {
                item.Status = statusEnum;
            }
            return incidentData.CreateAndUpdate(item);
        }

        public IncidentDataModel IncidentSeverityUpdate(int Id, SeverityEnum severityEnum)
        {
            IncidentDataModel item = incidentData.GetIncidentDatas.Where(x => x.IncidentID == Id).FirstOrDefault();
            if (item == null)
            {
                return item;
            }
            else
            {
                item.Severity = severityEnum;
            }
            return incidentData.CreateAndUpdate(item);
        }

        public bool IncidentDelete(int Id)
        {

            return incidentData.Delete(Id);
        }

    }
}

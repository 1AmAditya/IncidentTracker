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
            if (incidentDataModel.IncidentID == 0)
            {
                incidentDataModel.CreatedAt = DateTime.Now;
                incidentDataModel.Severity = null;
                incidentDataModel.Status = null;
                incidentDataModel.UpdatedAt = null;
                return incidentData.CreateAndUpdate(incidentDataModel);
            }
            else
            {
                var itemToRemove = incidentData.GetIncidentDatas.Single(r => r.IncidentID == incidentDataModel.IncidentID);
                incidentDataModel.UpdatedAt = DateTime.Now;
                incidentDataModel.CreatedAt = itemToRemove.CreatedAt;
                incidentDataModel.Severity = incidentDataModel.Severity;
                incidentDataModel.Status = incidentDataModel.Status;
                return incidentData.CreateAndUpdate(incidentDataModel);
            }
            return null;
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
                item.UpdatedAt = DateTime.Now;
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
                item.UpdatedAt = DateTime.Now;
                item.Severity = severityEnum;
                return incidentData.CreateAndUpdate(item);
            }
        }

        public bool IncidentDelete(int Id)
        {

            return incidentData.Delete(Id);
        }

    }
}

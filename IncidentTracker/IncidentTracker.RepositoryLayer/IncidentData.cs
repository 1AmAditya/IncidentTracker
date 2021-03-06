using IncidentTracker.Common.Interface;
using IncidentTracker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentTracker.RepositoryLayer
{
    public class IncidentData : IIncidentData
    {
        private List<IncidentDataModel> incidentDatas;
        private int counter = 0;

        public IncidentData()
        {
            incidentDatas = new List<IncidentDataModel>();
        }

        public List<IncidentDataModel> GetIncidentDatas
        {
            get
            {
                return incidentDatas;
            }
        }

        public IncidentDataModel CreateAndUpdate(IncidentDataModel incidentData)
        {

            if(incidentData.IncidentID == 0)
            {
                counter++;
                incidentData.IncidentID = counter;
                incidentDatas.Add(incidentData);
                return incidentData;
            }
            else 
            {
                var itemToRemove = incidentDatas.Single(r => r.IncidentID == incidentData.IncidentID);
                incidentDatas.Remove(itemToRemove);
                incidentDatas.Add(incidentData);
                return incidentData;
            }
        }

        public bool Delete(int id)
        {

            var itemToRemove = incidentDatas.Single(r => r.IncidentID == id);

            if(itemToRemove != null)
            {
                incidentDatas.Remove(itemToRemove);
                return true;
            }
            
            return false;
        }
    }
}

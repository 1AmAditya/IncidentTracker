using IncidentTracker.BusinessLayer;
using IncidentTracker.Common.Interface;
using IncidentTracker.RepositoryLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IncidentTracker.Common.Enum.Enums;

namespace IncidentTracker.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create()
        {
            IncidentData incidentData = new IncidentData();
            IIncidentBusinessLayer incidentBusinessLayer = new IncidentBusinessLayer(incidentData);
            var item = incidentBusinessLayer.IncidentInsertUpdate(new Common.Model.IncidentDataModel() { IncidentID = 0,Description = "strring" })  ;
            Assert.IsNotNull(item);
        }


        [TestMethod]
        public void Get()
        {
            IncidentData incidentData = new IncidentData();
            IIncidentBusinessLayer incidentBusinessLayer = new IncidentBusinessLayer(incidentData);
            incidentBusinessLayer.IncidentInsertUpdate(new Common.Model.IncidentDataModel() { IncidentID = 0, Description = "strring" });
            Assert.IsNotNull(incidentData.GetIncidentDatas);
        }


        [TestMethod]
        public void Update()
        {
            IncidentData incidentData = new IncidentData();
            IIncidentBusinessLayer incidentBusinessLayer = new IncidentBusinessLayer(incidentData);
            incidentBusinessLayer.IncidentInsertUpdate(new Common.Model.IncidentDataModel() { IncidentID = 0, Description = "strring" });
            var item = incidentBusinessLayer.IncidentInsertUpdate(new Common.Model.IncidentDataModel() { IncidentID = 1, Description = "strring" });
            Assert.IsNotNull(item);
        }


        [TestMethod]
        public void UpdateStatus()
        {
            IncidentData incidentData = new IncidentData();
            IIncidentBusinessLayer incidentBusinessLayer = new IncidentBusinessLayer(incidentData);
            incidentBusinessLayer.IncidentInsertUpdate(new Common.Model.IncidentDataModel() { IncidentID = 0, Description = "strring" });
            var item = incidentBusinessLayer.IncidentStatusUpdate(1,StatusEnum.Inprogess);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void UpdateSeverity()
        {
            IncidentData incidentData = new IncidentData();
            IIncidentBusinessLayer incidentBusinessLayer = new IncidentBusinessLayer(incidentData);
            incidentBusinessLayer.IncidentInsertUpdate(new Common.Model.IncidentDataModel() { IncidentID = 0, Description = "strring" });
            var item = incidentBusinessLayer.IncidentSeverityUpdate(1, SeverityEnum.Medium);
            Assert.IsNotNull(item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static IncidentTracker.Common.Enum.Enums;

namespace IncidentTracker.Common.Model
{
    public class IncidentDataModel
    {
        [Required]
        public int IncidentID { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        public SeverityEnum? Severity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public StatusEnum? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_Receiver.Models
{
    public partial class JobTaskNew
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string AssignedTo { get; set; } = null!;
        public DateTime AssignedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarADHDApp.Models
{
    public class WorkSubtask
    {
        public string TitleSubtask { get; set; }
        public int Priority { get; set; }
        public string TitleWorkTask { get; set; }
        public WorkTask WorkTask { get; set; }
        public string CalendarUserEmail { get; set; }
        public CalendarUser CalendarUser { get; set; }
    }
}

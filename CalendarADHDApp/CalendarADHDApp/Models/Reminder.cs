using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarADHDApp.Models
{
    public class Reminder
    {
        public int MinBeforeTaskStart { get; set; }
        public string CalendarUserEmail { get; set; }
        public CalendarUser CalendarUser { get; set; }
    }
}

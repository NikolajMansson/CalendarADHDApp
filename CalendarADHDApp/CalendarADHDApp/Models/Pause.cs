using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarADHDApp.Models
{
    public class Pause
    {
        public int LengthOfPauseMin { get; set; }
        public string CalendarUserEmail { get; set; }
        public CalendarUser CalendarUser { get; set; }
    }
}

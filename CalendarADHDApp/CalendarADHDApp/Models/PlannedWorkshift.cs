using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarADHDApp.Models
{
    public class PlannedWorkshift
    {
        public int Id { get; set; }
        public string TitleWorkTask { get; set; }
        public WorkTask WorkTask { get; set; }
        public string CalendarUserEmail { get; set; }
        public CalendarUser CalendarUser { get; set; }
        public int MinutesWorking { get; set; }
        public int MinuteStartedWorking { get; set; }
        public int HourStartedWorking { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime DatePlannedWorkshift { get; set; }
    }
}

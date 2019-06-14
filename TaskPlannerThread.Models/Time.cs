using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlannerThread.Models
{
    public class Time
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateTime { get; set; }
        public int Do { get; set; }
        public int Timer { get; set; }
    }
}

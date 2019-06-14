using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlannerThread.Models;
using System.Data.Entity;

namespace DataPlannerThread.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public DbSet<Time> Works { get; set; }
    }
}

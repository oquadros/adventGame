using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4.Models
{
    internal class Individual
    {
        public int UpperAssignedTask { get; }

        public int LowerAssignedTask { get; }        

        public Individual (string assignedTasks)
        {
            LowerAssignedTask = (int)Convert.ChangeType(assignedTasks.Split('-')[0], typeof(int));
            UpperAssignedTask = (int)Convert.ChangeType(assignedTasks.Split('-')[1], typeof(int));
        }
    }
}

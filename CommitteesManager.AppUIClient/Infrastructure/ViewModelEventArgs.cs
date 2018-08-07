using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    public enum JoinDirectionEnum
    {
        After,
        Before
    }
    public class ViewModelEventArgs: EventArgs
    {
        public ViewModelEventArgs(JoinDirectionEnum joinDirection)
        {
            JoinType = joinDirection;
        }
        public JoinDirectionEnum JoinType { get; }
    }
}

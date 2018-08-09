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
    internal class ViewModelEventArgs : EventArgs
    {
        public ViewModelEventArgs(JoinDirectionEnum joinDirection, ViewModelSection newVModel)
        {
            JoinType = joinDirection;
            VMObject = newVModel;
        }
        public JoinDirectionEnum JoinType { get; private set; }
        public ViewModelSection VMObject{get; private set;}
    }
}

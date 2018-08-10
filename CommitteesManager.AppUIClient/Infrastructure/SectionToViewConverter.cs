using CommitteesManager.AppUIClient.View;
using CommitteesManager.AppUIClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    public class SectionToViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UserControl retValue;
            switch (value)
            {
                case PlaneMeetingViewModel pmvm:
                    retValue = new PlaneMeeting();                   
                    break;
                case FilterViewModel fvm:
                    retValue = new Filter();
                    break;
                case null:
                default:
                    retValue = null;
                    break;
            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using CommitteesManager.AppUIClient.View;
using CommitteesManager.AppUIClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CommitteesManager.AppUIClient.Infrastructure.Converters
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
                case CreateMeetingViewModel cmvm:
                    retValue = new CreateMeeting();
                    break;
                case FilterViewModel fvm:
                    retValue = new Filter();
                    break;
                case RegistryViewModel rvm:
                    retValue = new DecisionRegistry();
                    break;
                case IssuesViewModel ivm:
                    retValue = new Issues();
                    break;
                case ModifyProtocolViewModel mpvm:
                    retValue = new ModifyProtocol();
                    break;
                case null:
                default:
                    retValue = null;
                    break;
            }
            if (retValue != null)
            {
                retValue.DataContext = value;
            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

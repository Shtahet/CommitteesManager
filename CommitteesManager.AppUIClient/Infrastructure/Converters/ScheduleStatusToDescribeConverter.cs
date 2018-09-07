using CommitteesManager.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CommitteesManager.AppUIClient.Infrastructure.Converters
{
    class ScheduleStatusToDescribeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            ScheduleStatus status = (ScheduleStatus)value;
            switch (status)
            {
                case ScheduleStatus.Completed:

                    break;
                case ScheduleStatus.Preparing:
                    break;
                case ScheduleStatus.Scheduled:
                    break;
                case ScheduleStatus.InSession:
                    break;
                default:
                    break;
            }
            return "Windows";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

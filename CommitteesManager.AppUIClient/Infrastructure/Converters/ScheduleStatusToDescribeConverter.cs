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
                return Binding.DoNothing;

            string statusDescribe = String.Empty;
            ScheduleStatus status = (ScheduleStatus)value;
            switch (status)
            {
                case ScheduleStatus.Completed:
                    statusDescribe = "Комітет завершено";
                    break;
                case ScheduleStatus.Preparing:
                    statusDescribe = "Збір заявок";
                    break;
                case ScheduleStatus.Scheduled:
                    statusDescribe = "Комітет заплановано";
                    break;
                case ScheduleStatus.InSession:
                    statusDescribe = "Триває захист";
                    break;
                case ScheduleStatus.Undefine:
                    statusDescribe = "Не визначено";
                    break;
                case ScheduleStatus.Canceled:
                    statusDescribe = "Відмінено";
                    break;
                default:
                    break;
            }
            return statusDescribe;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

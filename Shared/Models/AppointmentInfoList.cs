using System.Collections.Generic;

namespace Shared.Models
{
    public class AppointmentInfoList
    {
        public IList<AppointmentInfo> AppointmentInfos { get; set; }

        public AppointmentInfoList()
        {
            AppointmentInfos = new List<AppointmentInfo>();
        }
    }
}
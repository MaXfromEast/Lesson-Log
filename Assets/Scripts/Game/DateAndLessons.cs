using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class DateAndLessons
    {
        private string date;
        private AllLessons allLessons = new AllLessons();

        public string Date
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }
        public AllLessons AllLessons
        {
            set
            {
                allLessons = value;
            }
            get
            {
                return allLessons;
            }
        }
    }
}

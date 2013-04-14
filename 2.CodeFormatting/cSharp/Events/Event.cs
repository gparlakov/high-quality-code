namespace Events
{
    using System;
    using System.Linq;
    using System.Text;

    public class Event : IComparable
    {
        private readonly DateTime date;
        private readonly string title;
        private readonly string location;

        public Event(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int byDate = this.date.CompareTo(other.date);
            int byTitle = this.title.CompareTo(other.title);
            int byLocation = this.location.CompareTo(other.location);
            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.AppendFormat(" | {0}", this.title);
            if (this.location != null && this.location != "")
            {
                toString.AppendFormat(" | {0}", this.location);
            }
            return toString.ToString();
        }
    }
}
using System;

namespace SkoleIntraKalender.Models
{
    public class Item
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StaffName { get; set; }
        public string Id { get; set; }
        public string[] Location { get; set; }
        public string Title { get; set; }
        public bool AllDay { get; set; }
    }
}

﻿using System;

namespace Shared
{
    public class ConferenceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
        public int AttendeesTotal { get; set; }

        public ConferenceModel()
		{
            Start = DateTime.Now;
		}
    }
}

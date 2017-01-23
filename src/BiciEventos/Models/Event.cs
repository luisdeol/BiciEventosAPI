using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BiciEventos.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double StartLatitude { get; set; }
        public double EndLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLongitude{ get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Invite> Invites { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Event()
        {
            Attendances = new List<Attendance>();
        }

        public Event(string title, string description, DateTime startDate, DateTime endDate, 
            double startLatitude, double endLatitude, double startLongitude, double endLongitude, 
            string startTime, string endTime, int userId)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            StartLatitude = startLatitude;
            EndLatitude = endLatitude;
            StartLongitude = startLatitude;
            EndLongitude = endLongitude;
            StartTime = startTime;
            EndTime = endTime;
            UserId = userId;
        }
    }
}
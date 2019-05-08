using CarPooling.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class NotificationDTO
    {
        public List<Request> Requests { get; set; }
        public int Count { get; set; }
    }
}

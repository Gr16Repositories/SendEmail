﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Models
{
    public class ReminderEmail
    {
        public string SubscriberName { get; set; }
        public string EmailAddress { get; set; }
        public string SubscriptionTypeName { get; set; }
    }
}

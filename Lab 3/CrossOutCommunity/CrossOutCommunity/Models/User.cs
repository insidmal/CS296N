﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Models
{
    public class User
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
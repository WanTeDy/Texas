﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Tehas.Frontend.Models
{
    public class PageModel
    {       
        public Int32 PageNumber { get; set; }
        public Int32 CategoryId { get; set; }
    }
}
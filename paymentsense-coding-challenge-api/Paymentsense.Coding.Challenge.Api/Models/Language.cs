﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Language
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
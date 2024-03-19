using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPIIntegration.Models
{
    public class CallAttempt
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; } = string.Empty;
    }
}
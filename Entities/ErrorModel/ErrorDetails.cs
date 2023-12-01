using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public string? message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}

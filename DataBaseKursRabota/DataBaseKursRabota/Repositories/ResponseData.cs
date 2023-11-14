using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Repositories
{
    public class ResponseData<T>
    {
        [JsonPropertyName("rows")]
        [Required]
        public List<T> Rows { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

}

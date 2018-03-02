using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JsonConsumer.Models
{
    public class Result
    {        
        public int id { get; set; }
        [Required(ErrorMessage = "Você deve inserir um país.")]
        public string country { get; set; }
        public string name { get; set; }
        [Required(ErrorMessage = "Você deve inserir um estado.")]
        public string abbr { get; set; }
        public string area { get; set; }
        public string largest_city { get; set; }
        public string capital { get; set; }
    }

    public class RestResponse
    {
        public RestResponse()
        {
            result = new Result();
            messages = new List<string>();
        }
        public List<string> messages { get; set; }
        public Result result { get; set; }
    }

    public class Estado
    {
        public Estado()
        {
            RestResponse = new RestResponse();
        }
        public RestResponse RestResponse { get; set; }
    }
}
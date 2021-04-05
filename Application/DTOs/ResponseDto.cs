using System.Collections.Generic;

namespace Application.DTOs
{
    public class ResponseDto
    {
        public int Status { get; set; }
        public object Result { get; set; }
        public List<string> Message { get; set; }
        public ResponseDto(List<string> message, int status, object result)
        {
            this.Message = message;
            this.Status = status;
            this.Result = result;
        }
    }
}
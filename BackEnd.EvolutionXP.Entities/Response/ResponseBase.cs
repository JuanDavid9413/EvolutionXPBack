using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BackEnd.EvolutionXP.Entities.Response
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            Code = (int)HttpStatusCode.OK;
            Message = "";
        }

        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}

using BackEnd.EvolutionXP.Entities.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BackEnd.EvolutionXP.Utilities
{
    public static class GenericUtility
    {
        public static void ResponseBaseCatch<T>(this ResponseBase<T> data, bool validate, string message, HttpStatusCode status)
        {
            ResponseBase<T> result = data;
            if (validate)
            {
                result.Code = (int)status;
                result.Message = message;
            }
        }
    }
}

﻿using System.Xml;

namespace CashFlow.Communication.Response
{
    public class ResponseErrorJson
    {

        public  string ErrorMessage { get; set; } = string.Empty;

        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
}

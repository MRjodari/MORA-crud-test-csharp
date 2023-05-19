﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string objectName, object id) : base($"{objectName} ({id}) was not found")
        {

        }
    }
}

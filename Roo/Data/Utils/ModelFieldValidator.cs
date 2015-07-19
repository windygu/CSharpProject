using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roo.Data
{
    public class ModelFieldValidator
    {
        public ModelFieldValidator(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }

    }
}

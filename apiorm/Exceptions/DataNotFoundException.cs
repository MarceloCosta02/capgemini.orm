using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Exceptions
{    

    public class DataNotFoundException : ApplicationException
    {
        /// <summary> 
        /// Excessão personalizada para dados não encontrados em requisições GET
        /// </summary>
        public DataNotFoundException(string message) : base(message) { }
    }
}

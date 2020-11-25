using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Exceptions
{
    public class ModelFieldIsNullException : ApplicationException
    {
        /// <summary> 
        /// Excessão personalizada para sinalizar campos vazios ou nulos na Model recebida
        /// </summary>
        public ModelFieldIsNullException(string message) : base(message) { }
    }
}

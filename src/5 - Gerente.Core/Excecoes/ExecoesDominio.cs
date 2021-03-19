using System;
using System.Collections.Generic;

namespace Gerente.Core.Excecoes
{
    public class ExecoesDominio : Exception
    {
        internal List<string> _erros;

        public IReadOnlyCollection<string> Erros => _erros;

        public ExecoesDominio()
        {
            
        }

        public ExecoesDominio(string mensagem, List<string> erros) : base(mensagem)
        {
            _erros = erros;
        }

        public ExecoesDominio(string mensagem) : base(mensagem)
        {
            
        }
        
        public ExecoesDominio(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAgil.Execao
{
    public class UsuarioNaoAtivo : Exception
    {
        public UsuarioNaoAtivo(string mensagem) : base(mensagem){}
    }
}
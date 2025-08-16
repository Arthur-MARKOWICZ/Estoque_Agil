using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAgil.Execao;

    public class ProdutoNaoEncontrado : Exception
    {
        public ProdutoNaoEncontrado(string mensagem) : base(mensagem){}
    }

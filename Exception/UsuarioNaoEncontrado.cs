namespace EstoqueAgil.Execao;

using System;

public class UsuarioNaoEncontrado : Exception
{
    public UsuarioNaoEncontrado(string mensagem) : base(mensagem){}
}
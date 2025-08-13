namespace EstoqueAgil.Execao;
using System;
public class ValidationException : Exception
{
    public ValidationException(string mensagem) : base(mensagem){}
}
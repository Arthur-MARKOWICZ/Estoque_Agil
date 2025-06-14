import { useEffect, useState } from "react";

interface Produto {
  id: string;
  nome: string;
  descricao: string;
  preco: number;
  estoqueAtual: number;
  categoria: number;
}

export default function ListaProdutos() {
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    fetch("http://localhost:5079/Produto/todos",{
        headers: {
         "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
    }) 
      .then((res) => {
        if (!res.ok) throw new Error("Erro ao buscar produtos");
        return res.json();
      })
      .then((data) => setProdutos(data))
      .catch((err) => console.error(err));
  }, []);

  return (
    <div>
      <h1>Lista de Produtos</h1>
      {produtos.length === 0 ? (
        <p>Nenhum produto encontrado.</p>
      ) : (
        <ul>
          {produtos.map((produto) => (
            <li key={produto.id}>
              <strong>{produto.nome}</strong> - {produto.descricao} - R${produto.preco}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

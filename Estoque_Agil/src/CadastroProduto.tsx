import { useState } from "react";

export default function CadastroProduto() {
  const [nome, setNome] = useState<string>("");
  const [preco, setPreco] = useState<number>(0);
  const [descricao, setDescricao] = useState<string>("");
  const [categoria, setCategoria] = useState<number>(0);
  const [estoqueAtual, setEstoqueAtual] = useState<number>(0);
  const [erro, setErro] = useState<string>("");
const categorias = [
  "Eletronico",
  "Informatica",
  "Vestuario",
  "Alimento",
  "Limpeza",
  "Outro"
];
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await fetch("http://localhost:5079/Produto/criar", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
         "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        body: JSON.stringify({
          nome,
          descricao,
          preco,
          estoqueAtual,
          categoria
        })
      });

      if (!response.ok) {
        throw new Error("Cadastro falhou");
      }

      const data = await response.json();
      console.log("Cadastro bem-sucedido:", data);
      alert("Cadastro realizado!");
    } catch (err) {
      console.error("Erro:", err);
      setErro("Erro ao cadastrar produto.");
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "auto", padding: "2rem" }}>
      <h2>Cadastro de Produto</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nome:</label><br />
          <input
            type="text"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Preço:</label><br />
          <input
            type="number"
            value={preco}
            onChange={(e) => setPreco(parseFloat(e.target.value))}
            required
            step="0.01"
            min="0"
          />
        </div>
        <div style={{ marginTop: "1rem" }}>
          <label>Descrição:</label><br />
          <textarea
            value={descricao}
            onChange={(e) => setDescricao(e.target.value)}
            required
          />
        </div>
        <div>
  <label>Categoria:</label>
  {categorias.map((cat, index) => (
    <div key={index}>
      <input
        type="radio"
        id={`categoria-${index}`}
        name="categoria"
        value={index}
        checked={categoria === index}
        onChange={() => setCategoria(index)}
        required
      />
      <label htmlFor={`categoria-${index}`}>{cat}</label>
    </div>
  ))}
</div>

        <div style={{ marginTop: "1rem" }}>
          <label>Estoque Atual:</label><br />
          <input
            type="number"
            value={estoqueAtual}
            onChange={(e) => setEstoqueAtual(parseInt(e.target.value))}
            required
            min="0"
          />
        </div>
        {erro && <p style={{ color: "red" }}>{erro}</p>}
        <button type="submit" style={{ marginTop: "1rem" }}>Cadastrar</button>
      </form>
    </div>
  );
}

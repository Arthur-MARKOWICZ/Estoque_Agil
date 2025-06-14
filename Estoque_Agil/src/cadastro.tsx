import { useState } from "react";

export default function Cadastro() {
    const [nome, setNome] = useState<string>("");
  const [email, setEmail] = useState<string>("");
  const [senha, setSenha] = useState<string>("");
  const [erro, setErro] = useState<string>("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await fetch("http://localhost:5079/Account/cadastro", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ nome,email, senha })
      });

      if (!response.ok) {
        throw new Error("cadastro falhou");
      }

      const data = await response.json();
      console.log("cadastro bem-sucedido:", data);
     
      alert("cadastro realizado!");

    } catch (err) {
      console.error("Erro:", err);
      setErro("E-mail ou senha inválidos");
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "auto", padding: "2rem" }}>
      <h2>cadastro</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Email:</label><br />
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
         <div>
          <label>Nome:</label><br />
          <input
            type="text"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
          />
        </div>
        <div style={{ marginTop: "1rem" }}>
          <label>Senha:</label><br />
          <input
            type="password"
            value={senha}
            onChange={(e) => setSenha(e.target.value)}
            required
          />
        </div>
        {erro && <p style={{ color: "red" }}>{erro}</p>}
        <button type="submit" style={{ marginTop: "1rem" }}>Cadastrar</button>
      </form>
    </div>
  );
}

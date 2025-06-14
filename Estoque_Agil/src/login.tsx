import { useState } from "react";

export default function Login() {
  const [email, setEmail] = useState<string>("");
  const [senha, setSenha] = useState<string>("");
  const [erro, setErro] = useState<string>("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await fetch("http://localhost:5079/Account/Login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ email, senha })
      });

      if (!response.ok) {
        throw new Error("Login falhou");
      }

      const data = await response.json();
      console.log("Login bem-sucedido:", data);
      localStorage.setItem("token", data.token);
      localStorage.setItem("nome",data.nome);
      console.log(localStorage.getItem("token"));
      console.log(localStorage.getItem("nome"));
     
      alert("Login realizado!");
      window.location.href = "/ListarProduto"
    } catch (err) {
      console.error("Erro:", err);
      setErro("E-mail ou senha inválidos");
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "auto", padding: "2rem" }}>
      <h2>Login</h2>
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
        <button type="submit" style={{ marginTop: "1rem" }}>Entrar</button>
      </form>
    </div>
  );
}

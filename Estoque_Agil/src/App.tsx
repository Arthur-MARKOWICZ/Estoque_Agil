import Login from "../src/login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Cadastro from "../src/cadastro";
import CadastroProduto from "../src/CadastroProduto";
import ListaProdutos from "../src/ListarProduto";
function App() {
  return (
     <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />
         <Route path="/cadastroProduto" element={<CadastroProduto />} />
          <Route path="/ListarProduto" element={<ListaProdutos />} />
      </Routes>
    </Router>
  );
}

export default App;
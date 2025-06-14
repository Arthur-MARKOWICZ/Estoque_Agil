import Login from "../src/login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Cadastro from "../src/cadastro";
import CadastroProduto from "../src/CadastroProduto";
function App() {
  return (
     <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />
         <Route path="/cadastroProduto" element={<CadastroProduto />} />
      </Routes>
    </Router>
  );
}

export default App;
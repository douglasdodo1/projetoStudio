import { Routes, Route } from "react-router-dom";
import Login from "./login"; // certifique-se de que o caminho está certo
import Home from "./home"; 
import Cadastro from "./cadastro";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/login" element={<Login />} />
      <Route path="/cadastro" element={<Cadastro />} />
    </Routes>
  );
}

export default App;

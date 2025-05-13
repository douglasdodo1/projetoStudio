import { Link } from "react-router-dom";

function Cadastro() {
  return (
    <div className="h-screen flex items-center justify-center">
      <form className="bg-white p-10 rounded-3xl shadow-xl w-[400px] max-w-md">
        <h2 className="text-3xl font-bold mb-6 text-pink-500 text-center">Cadastro</h2>

        <div className="mb-6 mt-8">
          <label className="block text-gray-600 mb-2">Nome</label>
          <input
            type="text"
            placeholder="Digite seu nome"
            className="w-full px-4 py-2 border-0 bg-pink-200 rounded-xl text-gray-600 font-mono"
          />
        </div>

        <div className="mb-6">
          <label className="block text-gray-600 mb-2">Email</label>
          <input
            type="email"
            placeholder="Digite seu e-mail"
            className="w-full px-4 py-2 border-0 bg-pink-200 rounded-xl text-gray-600 font-mono"
          />
        </div>

        <div className="mb-8">
          <label className="block text-gray-600 mb-2">Senha</label>
          <input
            type="password"
            placeholder="Crie uma senha"
            className="w-full px-4 py-2 border-0 bg-pink-200 rounded-xl text-gray-600 font-mono"
          />
        </div>
        <button
          type="submit"
          className="w-full bg-[#f472b6] hover:bg-pink-600 text-white font-semibold py-2 rounded-xl"
        >
          Cadastrar
        </button>

        <div className="mt-4 text-center">
          <span className="text-gray-600">Já tem uma conta? </span>
          <Link to="/login" className="text-pink-500 hover:underline font-semibold">
            Faça login
          </Link>
        </div>
      </form>
    </div>
  );
}

export default Cadastro;

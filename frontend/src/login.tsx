// src/Login.tsx

import { Link } from "react-router-dom";

function Login() {
  return (
    <div className="h-screen flex items-center justify-center">
      <form className="bg-white p-10 rounded-3xl shadow-xl w-[400px] max-w-md">
        <h2 className="text-3xl font-bold mb-6 text-pink-500 text-center">Login</h2>

        <div className="mb-6 mt-8">
          <label className="block text-gray-600 mb-2">Email</label>
          <input
            type="email"
            placeholder="Digite seu e-mail"
            className="w-full px-4 py-2 border-0 bg-pink-200 rounded-xl text-gray-600 font-mono"
          />
        </div>

        <div className="mb-2">
          <label className="block text-gray-600 mb-2">Senha</label>
          <input
            type="password"
            placeholder="Digite sua senha"
            className="w-full px-4 py-2 border-0 bg-pink-200 rounded-xl text-gray-600 font-mono"
          />
        </div>

        {/* Remember me */}
        <div className="mt-4 flex items-center mb-8">
          <input
            type="checkbox"
            id="remember"
            className="mr-2 accent-pink-400"
          />
          <label htmlFor="remember" className="text-gray-600">
            Lembrar de mim
          </label>
        </div>

        <button
          type="submit"
          className="w-full bg-[#f472b6] hover:bg-pink-600 text-white font-semibold py-2 rounded-xl"
        >
          Entrar
        </button>

        {/* Link para cadastro */}
        <div className="mt-4 text-center">
          <span className="text-gray-600">Não tem uma conta? </span>
          <Link to="/cadastro" className="text-pink-500 hover:underline font-semibold">
            Cadastre-se
          </Link>
        </div>
      </form>
    </div>
  );
}

export default Login;

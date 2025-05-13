import mulherbonita from "./assets/mulherbonita.jpg";
import { FaInstagram, FaMapMarkerAlt, FaClock } from "react-icons/fa";
import servico1 from "./assets/servico1_salao.jpg";
import servico2 from "./assets/servico2_unha.png";


function App() {
  return (
    <div className="h-fit flex flex-col items-center justify-start scroll-smooth">
      {/* Header fixo */}
      <header className="fixed top-0 left-0 w-full h-28 bg-[#f472b6] flex justify-center items-center z-50">
        <div className="flex justify-between w-7/12 px-6 text-white">
          <a href="#" className="text-3xl hover:text-pink-600 transition duration-300">
            HOME
          </a>
          <a href="#sobre" className="text-3xl hover:text-pink-600 transition duration-300">
            SOBRE
          </a>
          <a
            href="#contato"
            className="text-3xl hover:text-pink-600 transition duration-300"
          >
            CONTATO
          </a>
        </div>
      </header>

      {/* Seção principal */}
      <div
        id="home"
        className="mt-40 bg-white w-[1200px] h-[600px] rounded-3xl flex items-center justify-center px-10 shadow-lg"
      >
        {/* Lado esquerdo */}
        <div className="flex flex-col justify-center items-start h-full w-1/2 gap-6 pl-20">
          <h1 className="text-pink-600 text-4xl font-bold">NOME DA MARCA</h1>
          <h2 className="text-[#868686] text-lg">
            Descrição da marca ou serviço
          </h2>
          <a
            href="#servicos"
            className="bg-[#f472b6] px-6 py-2 rounded-xl text-white text-sm w-fit hover:bg-pink-600 duration-300 transition"
          >
            Serviços
          </a>
        </div>

        {/* Lado direito */}
        <div className="flex items-center h-full w-1/2 pr-20 justify-end">
          <img
            src={mulherbonita}
            alt="Imagem ilustrativa"
            className="rounded-2xl w-[380px] h-[380px] object-cover"
          />
        </div>
      </div>

      {/* Seção SOBRE */}
      <div
        id="sobre"
        className="min-h-screen flex items-center justify-center"
      >
        <div className="grid grid-cols-3 gap-12 w-[1200px]">
          {/* Card 1 */}
          <div className="bg-white p-8 rounded-3xl shadow-xl hover:transform hover:-translate-y-2 duration-300 hover:shadow-2xl transition-all overflow-visible">
            <div className="text-[#f472b6] text-5xl mb-4">👥</div>
            <h3 className="text-2xl font-bold mb-3 text-pink-600">
              Equipe Qualificada
            </h3>
            <p className="text-[#868686]">
              Profissionais especializados e dedicados
            </p>
          </div>

          {/* Card 2 */}
          <div className="bg-white p-8 rounded-3xl shadow-xl hover:transform hover:-translate-y-2 duration-300 hover:shadow-2xl transition-all overflow-visible">
            <div className="text-[#f472b6] text-5xl mb-4">🎯</div>
            <h3 className="text-2xl font-bold mb-3 text-pink-600">
              Metodologia
            </h3>
            <p className="text-[#868686]">
              Processos otimizados para resultados
            </p>
          </div>

          {/* Card 3 */}
          <div className="bg-white p-8 rounded-3xl shadow-xl hover:transform hover:-translate-y-2 duration-300 hover:shadow-2xl transition-all overflow-visible">
            <div className="text-[#f472b6] text-5xl mb-4">🏆</div>
            <h3 className="text-2xl font-bold mb-3 text-pink-600">
              Conquistas
            </h3>
            <p className="text-[#868686]">Prêmios e reconhecimentos</p>
          </div>
        </div>
      </div>

{/* Seção SERVIÇOS */}
<div
  id="servicos"
  className="scroll-mt-35 min-h-screen flex-col items-center justify-center py-26"
>
  <div className="text-center mb-18">
    <h2 className="text-white font-bold text-4xl">Nossos Serviços</h2>
  </div>

  <div className="w-full max-w-5xl px-6">
    <div className="grid grid-cols-1 md:grid-cols-2 gap-16">
      {/* Serviço 1 */}
      <div className="w-100 flex flex-col bg-white rounded-3xl shadow-lg overflow-hidden transform transition duration-300 hover:shadow-2xl max-h-[460px] hover:scale-99">
        <div className="relative h-80 w-full overflow-hidden">
          <img
            src={servico1}
            alt="Serviço de salão"
            className="w-full h-60 transition duration-500 hover:scale-105"
          />
          <div className="absolute inset-0 bg-gradient-to-t from-black/60 to-transparent"></div>
        </div>
        <div className="p-6 flex-grow flex flex-col my-2">
          <h3 className="text-2xl font-bold text-pink-600 mb-3">Cabelo</h3>
          <p className="text-[#868686] mb-4 flex-grow">
            Corte, escova, hidratação e tratamentos capilares.
          </p>
          <div className="flex flex-wrap gap-2 mb-4 ">
            <span className="bg-pink-200 text-pink-600 px-3 py-1 rounded-full text-sm">Corte</span>
            <span className="bg-pink-200 text-pink-600 px-3 py-1 rounded-full text-sm">Hidratação</span>
          </div>
          <button className="bg-[#f472b6] hover:bg-pink-600 text-white px-6 py-2 rounded-xl transition duration-300 w-full">
            Agendar
          </button>
        </div>
      </div>

      {/* Serviço 2 */}
      <div className="w-100 flex flex-col bg-white rounded-3xl shadow-lg overflow-hidden transform transition duration-300 hover:shadow-2xl max-h-[460px] hover:scale-99">
        <div className="relative h-80 w-full overflow-hidden">
          <img
            src={servico2}
            alt="Serviço de unha"
            className="w-full h-60 transition duration-500 hover:scale-150"
          />
          <div className="absolute inset-0 bg-gradient-to-t from-black/60 to-transparent"></div>
        </div>
        <div className="p-6 flex-grow flex flex-col my-2">
          <h3 className="text-2xl font-bold text-pink-600 mb-3">Manicure</h3>
          <p className="text-[#868686] mb-4 flex-grow">
            Unhas impecáveis com designs exclusivos.
          </p>
          <div className="flex flex-wrap gap-2 mb-4">
            <span className="bg-pink-200 text-pink-600 px-3 py-1 rounded-full text-sm">Design</span>
          </div>
          <button className="bg-[#f472b6] hover:bg-pink-600 text-white px-6 py-2 rounded-full transition duration-300 w-full">
            Agendar
          </button>
        </div>
      </div>
    </div>
  </div>
</div>

      

      {/* Seção CONTATO */}
      {/* Seção CONTATO */}
      <div
        id="contato"
        className="scroll-mt-15 min-h-screen flex flex-col items-center justify-center"
      >
        <div className="text-center mb-18">
          <h2 className="text-white font-bold text-4xl">
            Entre em Contato
          </h2>
        </div>

        {/* Card Único */}
        <div className="bg-white/20 backdrop-blur-sm p-10 rounded-3xl shadow-xl w-full max-w-6xl flex flex-col lg:flex-row gap-16 items-center">
          {/* Informações de contato */}
          <div className="w-full lg:w-1/2 space-y-12">
            {/* Instagram */}
            <div className="flex items-center gap-4">
              <a
                href="https://www.instagram.com/"
                target="_blank"
                rel="noopener noreferrer"
                className="bg-white p-4 rounded-full text-pink-600 text-2xl hover:bg-pink-500 duration-300 hover:scale-105 hover:text-white"
              >
                <FaInstagram />
              </a>
              <div>
                <h3 className="text-white font-bold text-lg">Instagram</h3>
                <p className="text-white">@nomedamarca</p>
              </div>
            </div>

            {/* Endereço */}
            <div className="flex items-center gap-4">
              <div className="bg-white p-4 rounded-full text-pink-600 text-2xl">
                <FaMapMarkerAlt />
              </div>

              <div>
                <h3 className="text-white font-bold text-lg">Endereço</h3>
                <p className="text-white">
                  Rua Fictícia, 123
                  <br />
                  Bairro Imaginário
                </p>
              </div>
            </div>

            {/* Horário */}
            <div className="flex items-center gap-4">
              <div className="bg-white p-4 rounded-full text-pink-600 text-2xl">
                <FaClock />
              </div>
              <div>
                <h3 className="text-white font-bold text-lg">Horário</h3>
                <p className="text-white">
                  Seg-Sex: 9h às 18h
                  <br />
                  Sábado: 9h às 13h
                </p>
              </div>
            </div>
          </div>

          {/* Mapa */}
          <div className="w-full lg:w-2/3 h-[360px] rounded-2xl overflow-hidden shadow-xl border-4 border-white/30">
            <iframe
              title="Localização"
              src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d126252.58770565897!2d-34.99409442430678!3d-8.047562726490575!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x7ab18a9f2f0e2db%3A0x8724efb365d90b2d!2sRecife%2C%20PE!5e0!3m2!1spt-BR!2sbr!4v1712766823041!5m2!1spt-BR!2sbr"
              width="100%"
              height="100%"
              style={{ border: 0 }}
              loading="lazy"
              referrerPolicy="no-referrer-when-downgrade"
              className="scale-105"
            ></iframe>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;

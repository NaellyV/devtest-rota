import { FiUser, FiSearch, FiEdit2, FiTrash2, FiChevronLeft, FiChevronRight } from 'react-icons/fi';

export default function ClientsPage() {
  // Dados mockados - substitua pela chamada à API
  const clients = [
    { id: 1, name: 'Auto Peças ABC', email: 'contato@autopecas.com', phone: '(11) 9999-8888', purchases: 12 },
    { id: 2, name: 'Oficina Master', email: 'master@oficina.com', phone: '(11) 7777-6666', purchases: 5 },
    // ... mais clientes
  ];

  return (
    <div className="bg-white p-6 rounded-xl shadow-lg">
      {/* Cabeçalho */}
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-gray-800">Clientes</h1>
        <button className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2 rounded-lg transition">
          + Novo Cliente
        </button>
      </div>

      {/* Barra de busca e filtros */}
      <div className="flex items-center justify-between mb-6">
        <div className="relative w-64">
          <FiSearch className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
          <input
            type="text"
            placeholder="Buscar cliente..."
            className="pl-10 pr-4 py-2 w-full border border-gray-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
          />
        </div>
        <select className="border border-gray-300 rounded-lg px-3 py-2 focus:ring-2 focus:ring-indigo-500">
          <option>Ordenar por</option>
          <option>Nome (A-Z)</option>
          <option>Nome (Z-A)</option>
          <option>Mais compras</option>
        </select>
      </div>

      {/* Tabela de clientes */}
      <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Nome</th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Contato</th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Compras</th>
              <th className="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase">Ações</th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {clients.map((client) => (
              <tr key={client.id} className="hover:bg-gray-50">
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="flex items-center">
                    <div className="flex-shrink-0 h-10 w-10 bg-indigo-100 rounded-full flex items-center justify-center">
                      <FiUser className="text-indigo-600" />
                    </div>
                    <div className="ml-4">
                      <div className="text-sm font-medium text-gray-900">{client.name}</div>
                      <div className="text-sm text-gray-500">{client.email}</div>
                    </div>
                  </div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                  {client.phone}
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <span className="px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-green-100 text-green-800">
                    {client.purchases} compras
                  </span>
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                  <button className="text-indigo-600 hover:text-indigo-900 mr-3">
                    <FiEdit2 />
                  </button>
                  <button className="text-red-600 hover:text-red-900">
                    <FiTrash2 />
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Paginação */}
      <div className="flex items-center justify-between mt-6">
        <div className="text-sm text-gray-500">
          Mostrando <span className="font-medium">1</span> a <span className="font-medium">10</span> de <span className="font-medium">24</span> clientes
        </div>
        <div className="flex space-x-2">
          <button className="px-3 py-1 border border-gray-300 rounded-md text-sm font-medium text-gray-700 bg-white hover:bg-gray-50">
            <FiChevronLeft />
          </button>
          <button className="px-3 py-1 border border-indigo-500 rounded-md text-sm font-medium text-indigo-600 bg-indigo-50">
            1
          </button>
          <button className="px-3 py-1 border border-gray-300 rounded-md text-sm font-medium text-gray-700 bg-white hover:bg-gray-50">
            2
          </button>
          <button className="px-3 py-1 border border-gray-300 rounded-md text-sm font-medium text-gray-700 bg-white hover:bg-gray-50">
            <FiChevronRight />
          </button>
        </div>
      </div>
    </div>
  );
}
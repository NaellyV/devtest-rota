import { FiShoppingCart, FiUsers, FiPackage, FiDollarSign, FiPieChart, FiBarChart2, FiPlusCircle, FiFileText } from 'react-icons/fi';

export default function Dashboard() {
  const userData = {
    name: "Maria Silva",
    role: "Administrador"
  };

  const summaryData = {
    clients: 245,
    products: 189,
    salesToday: 15,
    revenue: 8750.50
  };

  const recentSales = [
    { id: "#1001", client: "Auto Peças Ltda", date: "10/05/2023", value: 1250.00 },
    { id: "#1000", client: "Mecânica Rápida", date: "10/05/2023", value: 850.50 },
    { id: "#999", client: "Oficina Master", date: "09/05/2023", value: 2200.00 },
    { id: "#998", client: "Auto Center São Paulo", date: "09/05/2023", value: 650.00 },
    { id: "#997", client: "Peças & Cia", date: "08/05/2023", value: 1800.00 }
  ];

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col">
      {/* Cabeçalho */}
      <header className="bg-white shadow-sm">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16 items-center">
            <div className="flex items-center">
              <h1 className="text-xl font-bold text-indigo-600">Rota das Oficinas - E-commerce</h1>
              <nav className="ml-10 flex space-x-8">
                <a href="/clients" className="text-gray-700 hover:text-indigo-600 px-3 py-2 text-sm font-medium">Clientes</a>
                <a href="/products" className="text-gray-700 hover:text-indigo-600 px-3 py-2 text-sm font-medium">Produtos</a>
                <a href="#" className="text-gray-700 hover:text-indigo-600 px-3 py-2 text-sm font-medium">Vendas</a>
                <a href="#" className="text-gray-700 hover:text-indigo-600 px-3 py-2 text-sm font-medium">Relatórios</a>
              </nav>
            </div>
            
            <div className="flex items-center">
              <span className="bg-indigo-100 text-indigo-800 text-xs font-medium mr-4 px-2.5 py-0.5 rounded-full">
                {userData.role}
              </span>
              
              <div className="relative ml-3">
                <div className="flex items-center cursor-pointer">
                  <span className="rounded-full bg-indigo-200 h-8 w-8 flex items-center justify-center text-indigo-700 font-medium">
                    {userData.name.charAt(0)}
                  </span>
                  <span className="ml-2 text-sm font-medium text-gray-700">{userData.name}</span>
                </div>
                
                <div className="hidden origin-top-right absolute right-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5">
                  <div className="py-1">
                    <a href="#" className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Editar Perfil</a>
                    <a href="#" className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Configurações</a>
                    <a href="#" className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Sair</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </header>

      {/* Conteúdo Principal */}
      <main className="flex-1 py-6">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          {/* Cards Resumos */}
          <div className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-4 mb-6">
            <div className="bg-white overflow-hidden shadow rounded-lg hover:shadow-md transition">
              <div className="px-4 py-5 sm:p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0 bg-indigo-500 rounded-md p-3">
                    <FiUsers className="h-6 w-6 text-white" />
                  </div>
                  <div className="ml-5 w-0 flex-1">
                    <dt className="text-sm font-medium text-gray-500 truncate">Total de Clientes</dt>
                    <dd className="flex items-baseline">
                      <div className="text-2xl font-semibold text-gray-900">{summaryData.clients}</div>
                      <a href="#" className="ml-2 text-sm font-medium text-indigo-600 hover:text-indigo-500">Ver todos</a>
                    </dd>
                  </div>
                </div>
              </div>
            </div>

            <div className="bg-white overflow-hidden shadow rounded-lg hover:shadow-md transition">
              <div className="px-4 py-5 sm:p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0 bg-green-500 rounded-md p-3">
                    <FiPackage className="h-6 w-6 text-white" />
                  </div>
                  <div className="ml-5 w-0 flex-1">
                    <dt className="text-sm font-medium text-gray-500 truncate">Total de Produtos</dt>
                    <dd className="flex items-baseline">
                      <div className="text-2xl font-semibold text-gray-900">{summaryData.products}</div>
                      <a href="#" className="ml-2 text-sm font-medium text-indigo-600 hover:text-indigo-500">Ver todos</a>
                    </dd>
                  </div>
                </div>
              </div>
            </div>

            <div className="bg-white overflow-hidden shadow rounded-lg hover:shadow-md transition">
              <div className="px-4 py-5 sm:p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0 bg-yellow-500 rounded-md p-3">
                    <FiShoppingCart className="h-6 w-6 text-white" />
                  </div>
                  <div className="ml-5 w-0 flex-1">
                    <dt className="text-sm font-medium text-gray-500 truncate">Vendas Hoje</dt>
                    <dd className="flex items-baseline">
                      <div className="text-2xl font-semibold text-gray-900">{summaryData.salesToday}</div>
                      <a href="#" className="ml-2 text-sm font-medium text-indigo-600 hover:text-indigo-500">Ver todas</a>
                    </dd>
                  </div>
                </div>
              </div>
            </div>

            <div className="bg-white overflow-hidden shadow rounded-lg hover:shadow-md transition">
              <div className="px-4 py-5 sm:p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0 bg-blue-500 rounded-md p-3">
                    <FiDollarSign className="h-6 w-6 text-white" />
                  </div>
                  <div className="ml-5 w-0 flex-1">
                    <dt className="text-sm font-medium text-gray-500 truncate">Renda Mensal</dt>
                    <dd className="flex items-baseline">
                      <div className="text-2xl font-semibold text-gray-900">
                        {summaryData.revenue.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                      </div>
                      <div className="ml-2 flex items-baseline text-sm font-semibold text-green-600">
                        <span className="sr-only">Período</span>
                        <select className="ml-1 border-0 bg-transparent text-sm font-medium text-indigo-600 focus:outline-none">
                          <option>Mês</option>
                          <option>Semana</option>
                          <option>Hoje</option>
                        </select>
                      </div>
                    </dd>
                  </div>
                </div>
              </div>
            </div>
          </div>

          {/* Gráficos e Atalhos */}
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-6 mb-6">
            {/* Gráfico Vendas por Período */}
            <div className="bg-white shadow rounded-lg p-6 lg:col-span-2">
              <div className="flex items-center justify-between mb-4">
                <h2 className="text-lg font-medium text-gray-900">Vendas por Período</h2>
                <div className="flex space-x-2">
                  <button className="px-3 py-1 text-sm bg-indigo-100 text-indigo-700 rounded-md">7 dias</button>
                  <button className="px-3 py-1 text-sm bg-white text-gray-700 rounded-md border">30 dias</button>
                </div>
              </div>
              <div className="h-64 bg-gray-50 rounded-md flex items-center justify-center">
                <FiBarChart2 className="h-16 w-16 text-gray-300" />
                <span className="ml-2 text-gray-400">Gráfico de vendas</span>
              </div>
            </div>

            {/* Gráfico Produtos Mais Vendidos */}
            <div className="bg-white shadow rounded-lg p-6">
              <h2 className="text-lg font-medium text-gray-900 mb-4">Produtos Mais Vendidos</h2>
              <div className="h-64 bg-gray-50 rounded-md flex items-center justify-center">
                <FiPieChart className="h-16 w-16 text-gray-300" />
                <span className="ml-2 text-gray-400">Gráfico de produtos</span>
              </div>
            </div>
          </div>

          {/* Atalhos Rápidos */}
          <div className="mb-6">
            <div className="flex flex-wrap gap-4">
              <a href="#" className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none">
                <FiPlusCircle className="mr-2" /> Nova Venda
              </a>
              <a href="#" className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-green-600 hover:bg-green-700 focus:outline-none">
                <FiPlusCircle className="mr-2" /> Cadastrar Produto
              </a>
              <a href="#" className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-purple-600 hover:bg-purple-700 focus:outline-none">
                <FiFileText className="mr-2" /> Gerar Relatório
              </a>
            </div>
          </div>

          {/* Últimas Vendas */}
          <div className="bg-white shadow rounded-lg overflow-hidden">
            <div className="px-6 py-4 border-b border-gray-200 flex items-center justify-between">
              <h2 className="text-lg font-medium text-gray-900">Últimas Vendas</h2>
              <a href="#" className="text-sm font-medium text-indigo-600 hover:text-indigo-500">Ver todas</a>
            </div>
            <div className="overflow-x-auto">
              <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-50">
                  <tr>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">ID</th>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Cliente</th>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Data</th>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Valor</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                  {recentSales.map((sale) => (
                    <tr key={sale.id} className="hover:bg-gray-50">
                      <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{sale.id}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{sale.client}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{sale.date}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                        {Number(sale.value).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </main>

      {/* Rodapé */}
      <footer className="bg-white border-t border-gray-200 py-4">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <p className="text-center text-sm text-gray-500">
            Rota das Oficinas - E-commerce v1.0 • contato@rotadasoficinas.com.br
          </p>
        </div>
      </footer>
    </div>
  );
}
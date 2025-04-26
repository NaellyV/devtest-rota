import { FiShoppingCart, FiUsers, FiPackage, FiDollarSign, FiPieChart, FiBarChart2, FiPlusCircle, FiFileText, FiLogOut } from 'react-icons/fi';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/router';
import { fetchApi } from '../lib/api';

interface UserData {
  userName: string;
  role: string;
}

interface SummaryData {
  clients: number;
  products: number;
  salesToday: number;
  revenue: number;
}

interface Sale {
  id: string;
  client: string;
  date: string;
  value: number;
}

export default function Dashboard() {
  const router = useRouter();
  const [userData, setUserData] = useState<UserData>({
    userName: "",
    role: ""
  });

  const [summaryData, setSummaryData] = useState<SummaryData>({
    clients: 0,
    products: 0,
    salesToday: 0,
    revenue: 0
  });

  const [recentSales, setRecentSales] = useState<Sale[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem('authToken') || sessionStorage.getItem('authToken');
    if (!token) {
      router.push('/login');
      return;
    }

    loadDashboardData(token);
  }, []);

  const loadDashboardData = async (token: string) => {
    try {
      const userResponse = await fetchApi('User/me', {
        headers: {
          'Authorization': `Bearer ${token}`
        }
      });

      if (!userResponse.ok) throw new Error('Failed to load user data');
      
      const user = await userResponse.json();
      setUserData({
        userName: user.name,
        role: user.role === 1 ? 'Administrador' : 'Cliente'
      });

      const [summaryRes, salesRes] = await Promise.all([
        fetchApi('Dashboard/summary', {
          headers: {
            'Authorization': `Bearer ${token}`
          }
        }),
        fetchApi('Sales/recent', {
          headers: {
            'Authorization': `Bearer ${token}`
          }
        })
      ]);

      if (!summaryRes.ok || !salesRes.ok) throw new Error('Failed to load dashboard data');

      setSummaryData(await summaryRes.json());
      setRecentSales(await salesRes.json());

    } catch (error) {
      console.error('Dashboard error:', error);
      if (error instanceof Error && error.message.includes('401')) {
        router.push('/login');
      }
    } finally {
      setIsLoading(false);
    }
  };

  const handleLogout = () => {
    localStorage.removeItem('authToken');
    sessionStorage.removeItem('authToken');
    router.push('/login');
  };

  if (isLoading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="text-center">
          <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-indigo-500 mx-auto"></div>
          <p className="mt-4 text-gray-600">Carregando dashboard...</p>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col">
      {/* Header */}
      <header className="bg-white shadow-sm">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16 items-center">
            <div className="flex items-center">
              <h1 className="text-xl font-bold text-indigo-600">Rota das Oficinas</h1>
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
              
              <div className="relative ml-3 group">
                <div className="flex items-center cursor-pointer">
                  <span className="rounded-full bg-indigo-200 h-8 w-8 flex items-center justify-center text-indigo-700 font-medium">
                    {userData.userName.charAt(0)}
                  </span>
                  <span className="ml-2 text-sm font-medium text-gray-700">{userData.userName}</span>
                </div>
                
                <div className="hidden group-hover:block origin-top-right absolute right-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 z-10">
                  <div className="py-1">
                    <a href="#" className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Perfil</a>
                    <button 
                      onClick={handleLogout}
                      className="w-full text-left block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 flex items-center"
                    >
                      <FiLogOut className="mr-2" /> Sair
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </header>

      {/* Main Content */}
      <main className="flex-1 py-6">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          {/* Summary Cards */}
          <div className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-4 mb-6">
            <div className="bg-white overflow-hidden shadow rounded-lg hover:shadow-md transition">
              <div className="px-4 py-5 sm:p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0 bg-indigo-500 rounded-md p-3">
                    <FiUsers className="h-6 w-6 text-white" />
                  </div>
                  <div className="ml-5 w-0 flex-1">
                    <dt className="text-sm font-medium text-gray-500 truncate">Clientes</dt>
                    <dd className="flex items-baseline">
                      <div className="text-2xl font-semibold text-gray-900">{summaryData.clients}</div>
                      <a href="/clients" className="ml-2 text-sm font-medium text-indigo-600 hover:text-indigo-500">Ver todos</a>
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
                    <dt className="text-sm font-medium text-gray-500 truncate">Produtos</dt>
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
                    <dt className="text-sm font-medium text-gray-500 truncate">Receita</dt>
                    <dd className="flex items-baseline">
                      <div className="text-2xl font-semibold text-gray-900">
                        {summaryData.revenue.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                      </div>
                    </dd>
                  </div>
                </div>
              </div>
            </div>
          </div>

          {/* Charts */}
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-6 mb-6">
            <div className="bg-white shadow rounded-lg p-6 lg:col-span-2">
              <h2 className="text-lg font-medium text-gray-900 mb-4">Vendas Recentes</h2>
              <div className="h-64 bg-gray-50 rounded-md flex items-center justify-center">
                <FiBarChart2 className="h-16 w-16 text-gray-300" />
                <span className="ml-2 text-gray-400">Gráfico de vendas</span>
              </div>
            </div>

            <div className="bg-white shadow rounded-lg p-6">
              <h2 className="text-lg font-medium text-gray-900 mb-4">Produtos Populares</h2>
              <div className="h-64 bg-gray-50 rounded-md flex items-center justify-center">
                <FiPieChart className="h-16 w-16 text-gray-300" />
                <span className="ml-2 text-gray-400">Gráfico de produtos</span>
              </div>
            </div>
          </div>

          {/* Quick Actions */}
          <div className="mb-6">
            <div className="flex flex-wrap gap-4">
              <a href="#" className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700">
                <FiPlusCircle className="mr-2" /> Nova Venda
              </a>
              <a href="#" className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-green-600 hover:bg-green-700">
                <FiPlusCircle className="mr-2" /> Novo Produto
              </a>
              <a href="#" className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-purple-600 hover:bg-purple-700">
                <FiFileText className="mr-2" /> Relatório
              </a>
            </div>
          </div>

          {/* Recent Sales */}
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
                        {sale.value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </main>

      {/* Footer */}
      <footer className="bg-white border-t border-gray-200 py-4">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <p className="text-center text-sm text-gray-500">
            © {new Date().getFullYear()} Rota das Oficinas - Todos os direitos reservados
          </p>
        </div>
      </footer>
    </div>
  );
}
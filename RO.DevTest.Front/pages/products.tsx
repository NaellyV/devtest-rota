export default function ProductsPage() {
    // Dados mockados
    const products = [
      { id: 1, name: 'Pastilha de Freio', price: 89.90, stock: 45, category: 'Freios' },
      { id: 2, name: 'Óleo Motor 5W30', price: 34.90, stock: 120, category: 'Lubrificantes' },
      // ... mais produtos
    ];
  
    return (
      <div className="bg-white p-6 rounded-xl shadow-lg">
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-2xl font-bold text-gray-800">Produtos</h1>
          <button className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2 rounded-lg transition">
            + Novo Produto
          </button>
        </div>
  
        {/* Filtros */}
        <div className="grid grid-cols-1 md:grid-cols-4 gap-4 mb-6">
          <input
            type="text"
            placeholder="Buscar produto..."
            className="col-span-2 px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-indigo-500"
          />
          <select className="border border-gray-300 rounded-lg px-4 py-2 focus:ring-2 focus:ring-indigo-500">
            <option>Todas categorias</option>
            <option>Freios</option>
            <option>Lubrificantes</option>
            {/* ... */}
          </select>
          <select className="border border-gray-300 rounded-lg px-4 py-2 focus:ring-2 focus:ring-indigo-500">
            <option>Ordenar por</option>
            <option>Preço (menor-maior)</option>
            <option>Preço (maior-menor)</option>
            <option>Nome (A-Z)</option>
          </select>
        </div>
  
        {/* Lista de produtos */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {products.map((product) => (
            <div key={product.id} className="border border-gray-200 rounded-lg overflow-hidden hover:shadow-md transition">
              <div className="bg-gray-100 h-48 flex items-center justify-center">
                <span className="text-gray-400">Imagem do produto</span>
              </div>
              <div className="p-4">
                <div className="flex justify-between items-start">
                  <h3 className="font-medium text-gray-900">{product.name}</h3>
                  <span className="font-bold text-indigo-600">
                    {product.price.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                  </span>
                </div>
                <div className="mt-2 text-sm text-gray-500">
                  <span>Categoria: {product.category}</span>
                  <span className="ml-4">Estoque: {product.stock}</span>
                </div>
                <div className="mt-4 flex space-x-2">
                  <button className="text-sm bg-indigo-600 hover:bg-indigo-700 text-white px-3 py-1 rounded">
                    Editar
                  </button>
                  <button className="text-sm bg-gray-200 hover:bg-gray-300 text-gray-800 px-3 py-1 rounded">
                    Detalhes
                  </button>
                </div>
              </div>
            </div>
          ))}
        </div>
  
        {/* Paginação (similar à de clientes) */}
      </div>
    );
  }
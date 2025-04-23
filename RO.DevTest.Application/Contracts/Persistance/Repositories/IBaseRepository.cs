using System.Linq.Expressions;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Creates a new entity in the database
        /// </summary>
        /// <param name="entity"> The entity to be created </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created entity </returns>
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds the first entity that matches with the <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate"> Expression to be used for filtering </param>
        /// <returns> The entity if found, null otherwise </returns>
        T? Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity"> The entity to be updated </param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity"> The entity to be deleted </param>
        void Delete(T entity);
    }
}

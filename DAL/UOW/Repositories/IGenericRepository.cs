using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        /// <summary>
        /// Permet de récupérer toutes les entités
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        
        /// <summary>
        /// Permet d'ajouter une entité
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);
        
        /// <summary>
        /// Permet de supprimer une entité
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
        
        /// <summary>
        /// Permet de récupérer une entité par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Permet de mettre à jour une entité
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);
    }
}

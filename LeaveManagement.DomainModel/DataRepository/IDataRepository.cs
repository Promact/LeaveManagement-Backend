using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LeaveManagement.DomainModel.DataRepository
{
    public interface IDataRepository
    {
        /// <summary>
        /// This return first element that definately matches with the provided expression
        /// </summary>
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>First element that matches all the condition</returns>
        T First<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// This return first element that definately matches with the provided expression asynchronously
        /// </summary>
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>First element that matches all the condition</returns>
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Filters data based on predicate.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>IQueryable containing filtered elements.</returns>
        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Method to select only required data
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <typeparam name="Tresult">Returned model class.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>select query</returns>
        IQueryable<Tresult> Select<T, Tresult>(Expression<Func<T, Tresult>> predicate) where T : class;

        /// <summary>
        /// Retrieves all the data.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <returns>List of all the elements.</returns>
        IQueryable<T> GetAll<T>() where T : class;

        /// <summary>
        /// Adds entity to the database asynchronously
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to add.</param>
        Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Adds entity to the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to add.</param>
        EntityEntry<T> Add<T>(T entity) where T : class;

        /// <summary>
        /// Adds entities to the database asynchronously
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to add.</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Adds the given collection of entities into context 
        /// </summary>
        /// <typeparam name="T">Model class to add the data</typeparam>
        /// <param name="entities">List of entities that need to be added</param>
        /// <returns>Void</returns>
        void AddRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Updates entity in the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to update.</param>
        EntityEntry<T> Update<T>(T entity) where T : class;


        /// <summary>
        /// Updates entities in the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entities to update.</param>
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Remove entity from the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to remove.</param>
        EntityEntry<T> Remove<T>(T entity) where T : class;

        /// <summary>
        /// Remove entities from the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to remove.</param>
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Method to begin database transaction.
        /// </summary>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Method to commit database transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Method to rollback database transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Add data in bulk using bulk extentions methods asynchronously
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to add.</param>
        Task BulkInsertAsync<T>(List<T> entities) where T : class;

        /// <summary>
        /// Delete bulk data from db ashynchronously
        /// </summary>
        /// <typeparam name="T">Model class</typeparam>
        /// <param name="entities">List of data that are to be deleted in bulk</param>
        /// <returns>Task</returns>
        Task BulkDeleteAsync<T>(List<T> entities) where T : class;

        /// <summary>
        /// Update bulk data in db ashynchronously
        /// </summary>
        /// <typeparam name="T">Model class</typeparam>
        /// <param name="entities">List of data that are to be updated in bulk</param>
        /// <returns>Task</returns>
        Task BulkUpdateAsync<T>(List<T> entities) where T : class;

        /// <summary>
        /// This will update data when any PK matches otherwise will insert data in db asynchronously
        /// </summary>
        /// <typeparam name="T">Model class</typeparam>
        /// <param name="entities">List of data that are to be inserted or updated in bulk</param>
        /// <returns>Task</returns>
        Task BulkInsertOrUpdateAsync<T>(List<T> entities) where T : class;

        /// <summary>
        /// Method to find data from database using its id asynchronously.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="id">Id of data i.e primary key.</param>
        Task<T> FindAsync<T>(int id) where T : class;

        /// <summary>
        /// Method to find data from database using its id.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="id">Id of data i.e primary key.</param>
        T Find<T>(int id) where T : class;

        /// <summary>
        /// Checks where data exist in database or not.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>bool value whether data exist or not</returns>
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        // <summary>
        /// Determines if any data exists in database or not.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <returns>bool value based on existance of data</returns>
        Task<bool> AnyAsync<T>() where T : class;

        /// <summary>
        /// Checks where data exist in database or not.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>bool value whether data exist or not</returns>
        bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Calls SaveChanges on the db context.
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Updates entity in the database.
        /// </summary>
        /// <typeparam name="T"> Model class to create DbSet. </typeparam>
        /// <param name="entity"> Entity to update. </param>
        EntityEntry<T> Attach<T>(T entity) where T : class;

        /// <summary>
        /// updates entities to the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to update.</param>
        void AttachRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// This return first element that definately matches with the provided expression
        /// otherwise return null if no element found asynchronously
        /// </summary>
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>First element that matches all the condition otherwise null</returns>
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Method to get number of rows in a Dbset.
        /// </summary>
        /// <typeparam name="T">Model class to fetch DbSet.</typeparam>
        /// <returns>Count of rows available.</returns>
        Task<int> CountAsync<T>() where T : class;

        /// This return first element that definately matches with the provided expression
        /// otherwise return null if no element found
        /// </summary>
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>First element that matches all the condition otherwise null</returns>
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Method to get no of rows satisfing the applied condition
        /// </summary>
        /// <typeparam name="T">Model class to fetch DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Filtered elements count</returns>
        Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Method to get entity using SingleOrDefaultAsync
        /// </summary>
        /// <typeparam name="T">Model class to fetch DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Filtered elements</returns>
        Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;


        /// <summary>
        /// Method to load virtual data in an entity
        /// </summary>
        /// <typeparam name="T">Model class to get entry</typeparam>
        /// <typeparam name="propertyExpression">Lambda expression to find vitual data</typeparam>
        /// <returns>Task</returns>
        /// public async Task LoadReferenceForEntry<T, TProperty>(T entry, Expression<Func<T, object>> propertyExpression) where T : class
        Task LoadReferenceForEntry<T>(T entry, Expression<Func<T, object>> propertyExpression) where T : class;


        /// <summary>
        /// Method to load virtual data in an entity
        /// </summary>
        /// <typeparam name="T">Model class to get entry</typeparam>
        /// <typeparam name="propertyExpression">Lambda expression to find vitual data as IEnumerable</typeparam>
        /// <returns>Task</returns>
        Task LoadCollectionForEntry<T>(T entry, Expression<Func<T, IEnumerable<object>>> propertyExpression) where T : class;

        /// <summary>
        /// Method to get entry for given entry (provides access to change tracking information and operations for the entity)
        /// </summary>
        /// <typeparam name="T">Model class to get entry</typeparam>
        EntityEntry Entry<T>(T entry) where T : class;

        /// <summary>
        /// Asynchronously returns the last element of a sequence that
        /// specify a specific condition
        /// </summary>
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>Task</returns>
        Task<T> LastOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Method to set IsModified property to true for given object's that is set in EntityEntry.
        /// </summary>
        /// <typeparam name="T">Model class for passed object.</typeparam>
        /// <param name="obj">Object for which changes are tracked by entity framework core.</param>
        /// <param name="propertyName">Name of the property of the object for which IsModified property will be set to true.</param>
        void SetPropertyIsModified<T>(T obj, string propertyName) where T : class;
    }
}

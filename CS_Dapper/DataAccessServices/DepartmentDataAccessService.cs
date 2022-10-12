using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CS_Dapper.Constants;
using CS_Dapper.DbConnect;
using CS_Dapper.Models;

namespace CS_Dapper.DataAccessServices
{
    /// <summary>
    /// USe Dapper to Manage CRUD Operations
    /// </summary>
    internal class DepartmentDataAccessService
    {
        EShopingCodiContext _context = null;
        public DepartmentDataAccessService()
        {
            _context = new EShopingCodiContext();
        }
        public async Task<List<Department>> GetAsync()
        {
            try
            {
                var query = StaticConstants.SelectQuery;
                // Generic Method that will accept a Model (e.g.Department)
                // and the Query eill be executed against the Deparment Table
                // (StaticConstants.SelectQuery) and the result ill be mapped with the Model
                var result = await _context.CreateConnection()
                        .QueryAsync<Department>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Department> CreateAsync(Department department)
        {
            try
            {
                var query = StaticConstants.InsertQuery;
                var parameters = new DynamicParameters();
                parameters.Add("@DeptNo", department.DeptNo, System.Data.DbType.Int32);
                parameters.Add("@DeptName", department.DeptName, System.Data.DbType.String);
                parameters.Add("@Location", department.Location, System.Data.DbType.String);
                parameters.Add("@Capacity", department.Capacity, System.Data.DbType.Int32);

                var result = await _context.CreateConnection()
                                .ExecuteAsync(query, parameters);
                if (result > 0)
                    return department;
                else
                    return null;    
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool isDeleted = false;
            try
            {
                var query = StaticConstants.DeleteQuery;
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptNo", id, System.Data.DbType.Int32);


                using (var conn = _context.CreateConnection())
                {
                    int result = await conn.ExecuteAsync(query, queryParameters);
                    if (result != 0)
                        isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isDeleted;
        }

        public async Task<Department> UpdateAsync(int id, Department entity)
        {
            try
            {
                var query =StaticConstants.UpdateQuery;
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptNo", entity.DeptNo, System.Data.DbType.Int32);
                queryParameters.Add("@DeptName", entity.DeptName, System.Data.DbType.String);
                queryParameters.Add("@Location", entity.Location, System.Data.DbType.String);
                queryParameters.Add("@Capacity", entity.Capacity, System.Data.DbType.Int32);

                using (var conn = _context.CreateConnection())
                {
                    int result = await conn.ExecuteAsync(query, queryParameters);
                    if (result != 0)
                        return entity;
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

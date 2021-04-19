using Dapper;
using DeveloperDeptInfo.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDeptInfo.DataAccess.Dapper
{
    class DeveloperRepository: IDeveloperRepository
    {
        protected readonly IConfiguration _config; 

        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }

        //Create an IDB connection object to database connection called Connection

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("DevelopersDbConnection")); }
        }

        public void AddDeveloper(Developer developer)
        {
            try 
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = "INSERT INTO Developer(DeveloperName, Email, Department, JoinDate) VALUES(@DeveloperName, @Email, @Department, @JoinDate)";
                    dbConnection.Execute(query, developer);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteDeveloper(int id)
        {
            try 
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = "DELETE FROM Developer WHERE Id=@Id";
                    dbConnection.Execute(query, new {Id = id});
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<IEnumerable<Developer>> GetAllDeveloperAsync()
        {
            try 
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT Id, DeveloperName, Email, Department, JoinDate FROM Developer";
                    return await dbConnection.QueryAsync<Developer>(query);
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<Developer> GetDeveloperByEmail(string Email)
        {
            try 
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT FROM Developer WHERE Email = @Email";
                    return await dbConnection.QueryFirstOrDefaultAsync(query, new { Email = @Email});
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public async Task<Developer> GetDeveloperByIdAsync(int Id)
        {
            try 
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developer WHERE Id = @Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Id = @Id });

                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void UpdateDeveloper(Developer developer)
        {
            try 
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Developer SET DeveloperName = @DeveloperNAME, Email = @Email, Department = @Department, JoinDate = @JoinDate";
                    dbConnection.Execute(query, developer);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}

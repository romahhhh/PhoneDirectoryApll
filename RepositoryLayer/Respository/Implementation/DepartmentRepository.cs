using DomainLayer.Models;
using RepositoryLayer.Respository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Respository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDatabase _db;

        public DepartmentRepository(IDatabase db)
        {
            _db = db;
        }

        public void Create(DepartmentModel entities)
        {
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.CreateDepquery, _db.Connection);
            newCommand.Parameters.AddWithValue("@Name", entities.Name);
            newCommand.Parameters.AddWithValue("@ParentDepId", entities.ParentDepId);
            newCommand.ExecuteNonQuery();
        }

        public void Delete(int ids)
        {
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.DeleteDepquery, _db.Connection);
            newCommand.Parameters.AddWithValue("@ids", ids);
            newCommand.ExecuteNonQuery();
        }

        public async Task<List<DepartmentDto>> GetEntities(bool x)
        {
            if (x == false)
            {
                List<DepartmentDto> data = new List<DepartmentDto>();
                SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.GetEntDepquery, _db.Connection);
                /*SQLiteDataReader*/ var result = await newCommand.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        DepartmentDto datas = new DepartmentDto
                        {
                            Id = int.Parse(result["id"].ToString()),
                            Name = (string)result["Name"],
                            ParentDepId = string.IsNullOrEmpty(result["ParentDepId"].ToString()) ? null : int.Parse(result["ParentDepId"].ToString())
                        };
                        data.Add(datas);
                    }
                }

                return data;

            }
            else//вывод сотрудников с подразделениями
            {
                List<DepartmentDto> data = new List<DepartmentDto>();
                SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.GetEntDepqueryW, _db.Connection);
                /*SQLiteDataReader*/ var result = await newCommand.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    List<WorkersModel> GetW()
                    {
                        List<WorkersModel> workersModelN = new List<WorkersModel>();
                        WorkersModel datas = new WorkersModel
                        {
                            Id = int.Parse(result["id:1"].ToString()),
                            FIO = (string)result["FIO"],
                            Phone = (string)result["Phone"],
                            UnderDepsId = int.Parse(result["UnderDepsId"].ToString())
                        };
                        workersModelN.Add(datas);
                        return workersModelN;
                    }

                    while (await result.ReadAsync())
                    {
                        DepartmentDto datas = new DepartmentDto
                        {
                            Id = int.Parse(result["id"].ToString()),
                            Name = (string)result["Name"],
                            ParentDepId = string.IsNullOrEmpty(result["ParentDepId"].ToString()) ? null : int.Parse(result["ParentDepId"].ToString()),
                            Workers = GetW()

                        };
                        data.Add(datas);
                    }
                }
                return data;
            }
        }

        public async Task<DepartmentModel> GetEntityById(int id)
        {
            DepartmentModel data = new DepartmentModel();
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.GetEntByIdDepquery, _db.Connection);
            newCommand.Parameters.AddWithValue("@id", id);
            /*SQLiteDataReader*/ var result = await newCommand.ExecuteReaderAsync();

            if (result.HasRows)
            {
                while (await result.ReadAsync())
                {
                    DepartmentModel datas = new DepartmentModel
                    {
                        Id = int.Parse(result["id"].ToString()),
                        Name = (string)result["Name"],
                        ParentDepId = int.Parse(result["ParentDepId"].ToString())

                    };
                    data = datas;
                }
            }
            return data;
        }

        public void Update(DepartmentModel entities)
        {
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.UpdateDepquery, _db.Connection);
            newCommand.Parameters.AddWithValue("@Name", entities.Name);
            newCommand.Parameters.AddWithValue("@ParentDepId", entities.ParentDepId);
            newCommand.ExecuteNonQuery();
        }
        public async Task<List<DepartmentModel>> Search(string word)
        {
            List<DepartmentModel> data = new List<DepartmentModel>();
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.SearchDepquery, _db.Connection);
            newCommand.Parameters.AddWithValue("@word", word);
            /*SQLiteDataReader*/var result = await newCommand.ExecuteReaderAsync();

            if (result.HasRows)
            {
                while (await result.ReadAsync())
                {
                    DepartmentModel user = new DepartmentModel
                    {
                        Id = int.Parse(result["id"].ToString()),
                        Name = (string)result["Name"],
                        ParentDepId = string.IsNullOrEmpty(result["ParentDepId"].ToString()) ? null : int.Parse(result["ParentDepId"].ToString())
                    };
                    data.Add(user);
                }
            }

            return data;
        }
    }
}

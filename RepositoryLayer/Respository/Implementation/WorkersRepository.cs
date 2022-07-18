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
    public class WorkersRepository : IWorkersRepository
    {
        private readonly IDatabase _db;
        public WorkersRepository(IDatabase db)
        {
            _db = db;
        }

        public void Create(WorkersModel entities)
        {
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.CreateWorkQuery, _db.Connection);
            newCommand.Parameters.AddWithValue("@FIO", entities.FIO);
            newCommand.Parameters.AddWithValue("@Phone", entities.Phone);
            newCommand.Parameters.AddWithValue("@UnderDepsId", entities.UnderDepsId);
            newCommand.ExecuteNonQuery();
        }

        public void Delete(int ids)
        {
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.DeleteWorkQuery, _db.Connection);
            newCommand.Parameters.AddWithValue("@ids", ids);
            newCommand.ExecuteNonQuery();
        }

        public async Task<List<WorkersModel>> GetEntities()
        {
            List<WorkersModel> data = new List<WorkersModel>();
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.GetEntWorkQuery, _db.Connection);

            /*SQLiteDataReader*/var result = await newCommand.ExecuteReaderAsync();

            if (result.HasRows)
            {
                while (await result.ReadAsync())
                {
                    WorkersModel user = new WorkersModel
                    {
                        Id = int.Parse(result["id"].ToString()),
                        FIO = (string)result["FIO"],
                        Phone = (string)result["Phone"],
                        UnderDepsId = int.Parse(result["UnderDepsId"].ToString())
                    };
                    data.Add(user);
                }
            }

            return data;
        }

        public async Task<WorkersModel> GetEntityById(int id)
        {
            WorkersModel data = new WorkersModel();
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.GetEntityByIdWorkQuery, _db.Connection);
            newCommand.Parameters.AddWithValue("@id", id);
            /*SQLiteDataReader*/var result = await newCommand.ExecuteReaderAsync();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    WorkersModel datas = new WorkersModel
                    {
                        Id = int.Parse(result["id"].ToString()),
                        FIO = (string)result["FIO"],
                        Phone = (string)result["Phone"],
                        UnderDepsId = int.Parse(result["UnderDepsId"].ToString())

                    };
                    data = datas;
                }
            }
            return data;
        }

        public void Update(WorkersModel entities)
        {
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.UpdateWorkQuery, _db.Connection);
            newCommand.Parameters.AddWithValue("@id", entities.Id);
            newCommand.Parameters.AddWithValue("@FIO", entities.FIO);
            newCommand.Parameters.AddWithValue("@Phone", entities.Phone);
            newCommand.Parameters.AddWithValue("@UnderDepsId", entities.UnderDepsId);
            newCommand.ExecuteNonQuery();
        }
        public async Task<List<WorkersModel>> Search(string word)
        {
            List<WorkersModel> data = new List<WorkersModel>();
            SQLiteCommand newCommand = new SQLiteCommand(SQLConstants.SearchWorkQuery, _db.Connection);
            newCommand.Parameters.AddWithValue("@word", word);
            /*SQLiteDataReader*/var result = await newCommand.ExecuteReaderAsync();

            if (result.HasRows)
            {
                while (await result.ReadAsync())
                {
                    WorkersModel user = new WorkersModel
                    {
                        Id = int.Parse(result["id"].ToString()),
                        FIO = (string)result["FIO"],
                        Phone = (string)result["Phone"],
                        UnderDepsId = int.Parse(result["UnderDepsId"].ToString())
                    };
                    data.Add(user);
                }
            }

            return data;
        }
    }
}

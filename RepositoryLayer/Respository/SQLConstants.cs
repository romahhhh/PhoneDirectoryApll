using DomainLayer.Models;
using RepositoryLayer.Respository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Respository
{
    public static class SQLConstants
    {
        // Для table Departaments
        public const string GetEntDepqueryW = "WITH TABLEE AS(SELECT* FROM Departaments AS D JOIN Workers AS W ON  W.UnderDepsId= D.id) SELECT* FROM TABLEE;";
        public const string GetEntDepquery = "SELECT * FROM Departaments";
        public const string GetEntByIdDepquery = "SELECT * FROM Departaments WHERE id=@id";
        public const string CreateDepquery = "INSERT INTO Departaments (`Name`,`ParentDepId`) VALUES (@Name,@ParentDepId)";
        public const string UpdateDepquery = "UPDATE Departaments SET Name=@Name, ParentDepId=@ParentDepId WHERE id=@entities.Id";
        public const string DeleteDepquery = "DELETE FROM Departaments WHERE id=@ids";
        public const string SearchDepquery = "SELECT * FROM Departaments WHERE id=@word or Name=@word or ParentDepId=@word";

        // Для table Workers
        public const string GetEntWorkQuery = "SELECT * FROM Workers";
        public const string GetEntityByIdWorkQuery = "SELECT * FROM Workers WHERE id=@id";
        public const string CreateWorkQuery = "INSERT INTO Workers (`FIO`,`Phone`,`UnderDepsId`) VALUES (@FIO,@Phone,@UnderDepsId)";
        public const string UpdateWorkQuery = "UPDATE Workers SET FIO=@FIO, Phone=@Phone, UnderDepsId=@UnderDepsId WHERE id=@id";
        public const string DeleteWorkQuery = "DELETE FROM Workers WHERE id=@ids";
        public const string SearchWorkQuery = "SELECT * FROM Workers WHERE id=@word or FIO=@word or Phone=@word or UnderDepsId=@word";

    }
}

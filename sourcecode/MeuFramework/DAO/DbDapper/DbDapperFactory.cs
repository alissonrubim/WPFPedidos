using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFramework.DAO.DbDapper
{
    public class DbDapperFactory
    {
        public IDbDapper Get()
        {
            return new DbDapperFactoryMySql(@"Server=localhost;Database=Pedidos;Uid=root;Pwd=root;");
            //return new DbDapperFactorySqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=pedidos;Data Source=DESKTOP-KIFPBAF\SQLEXPRESS");
        }
    }
}

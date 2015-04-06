using AC.Data.ConnString;
using AC.Transaction.Common;

namespace Art.Dao
{
    public class SizomUnitOfWorkFactory
    {
        public static IUnitOfWork GetUnitOfWorkOfSizom()
        {
            return AC.Transaction.Common.UnitOfWorkFactory.GetAdoNetUnitOfWork(ConnStringUtil.GetConnectionString("ConnStringOfSizom"));
        } 
    }
}
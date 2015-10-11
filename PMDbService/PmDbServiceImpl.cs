using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PMDbDataAccess;

namespace PMDbService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public partial class PmDbServiceImpl : IUserService
    {
        public List<string>[] GetData()
        {
            DbDataAccess dbData = new DbDataAccess();
            return dbData.GetUserTypesFromDb();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    public partial class PmDbServiceImpl : IAuthService
    {

    }
}

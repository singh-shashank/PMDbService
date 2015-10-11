using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDbDataAccess
{
    public static class DbTableUserType
    {
        public const string TableName = "pmdb.user_type";
        public const string UserTypeIdCol = "UserTypeId";
        public const string UserTypeNameCol = "UserTypeName";
    }

    public static class DbTableUser
    {
        public const string TableName = "pmdb.user";
        public const string UserIdCol = "UserId";
        public const string UserNameCol = "Username";
        public const string UserTypeIdCol = "UserTypeId";
        public const string EmailCol = "Email";
        public const string PasswordCol = "Password";
    }
    
    public static class DbCommonColumn
    {
        public const string CreateTimeCol = "CreateTime";
        public const string UpdateTimeCol = "UpdateTime";
        public const string IsObsoleteCol = "IsObsolete";
    }
}

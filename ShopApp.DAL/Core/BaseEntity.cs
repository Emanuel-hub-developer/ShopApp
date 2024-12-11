

using System.Data;

namespace ShopApp.DAL.Core
{
    public abstract class BaseEntity
    {
        public DateTime? creation_date { get; set; }

        public DateTime creation_user { get; set; }

        public DateTime? modify_date { get; set; }

        public int? modify_user { get; set; }


        public int? delete_user { get; set; }

        public DataSetDateTime? delete_date { get; set; }

        public bool deleted { get; set; }


    }
}

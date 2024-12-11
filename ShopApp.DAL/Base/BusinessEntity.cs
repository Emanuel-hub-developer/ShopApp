

namespace ShopApp.DAL.Core
{
    public abstract class BusinessEntity : CommonEntity
    {
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string fax { get; set; }
    }
}

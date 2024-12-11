

namespace ShopApp.DAL.Core
{
    public abstract class Person : CommonEntity
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}

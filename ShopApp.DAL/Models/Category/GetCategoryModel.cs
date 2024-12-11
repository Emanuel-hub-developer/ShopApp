

namespace ShopApp.DAL.Models.Category
{
    public class GetCategoryModel
    {

        public string? categoryname { get; set; }

        public string? description { get; set; }

        public int? categoryId { get; set; }

        public int? modify_user { get; set; }

        public DateTime? creation_date { get; set; }
        public DateTime ChangeDate { get;  set; }
    }
}

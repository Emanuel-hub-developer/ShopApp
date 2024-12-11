
namespace ShopApp.DAL.Models.Category
{
    public class CategoryCreateOrUpdateModel
    {
        public int categoryId { get; set; }

        public string categoryname { get; set; }    

        public string description { get; set; }
        public int UserId {  get; set; }

        public DateTime ChangeDate { get; set; }
    }
}

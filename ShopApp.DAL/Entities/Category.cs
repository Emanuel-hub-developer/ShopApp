﻿


using ShopApp.DAL.Core;

namespace ShopApp.DAL.Entities
{
    public class Category : BaseEntity
    {
        

        public int categoryid { get; set; }
        public string categoryname { get; set; }

        public string description { get; set; }
     
        
    }
}

using System;
namespace Blog.Mapper.ViewModels.CategoryViewModels
{
    public class CategoryDetailVM
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CreatedComputerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIp { get; set; }
    }
}

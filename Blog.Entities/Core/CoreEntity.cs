using System;

namespace Blog.Entities.Core
{
    public interface ICoreEntity { }
    public abstract class CoreEntity : ICoreEntity
    {
        public CoreEntity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedBy = "30BBB8C7-DEED-4AB9-A837-8E9167C8E79D";
            this.CreatedIp = "127.0.0.1";
            this.CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string CreatedComputerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIp { get; set; }
    }
}

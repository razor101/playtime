namespace PlayTime.Data.Models
{
    using System.Collections.Generic;

    public class Customer : BaseDataModel
    {
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
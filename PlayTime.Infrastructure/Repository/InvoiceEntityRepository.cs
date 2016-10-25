namespace PlayTime.Infrastructure.Repository
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using PlayTime.Data;
    using PlayTime.Data.Models;
    using PlayTime.Infrastructure.Interfaces;
    using PlayTime.Infrastructure.Interfaces.Repository;

    public class InvoiceEntityRepository : IBaseRepository<Invoice>, IInvoiceRepository
    {
        private PlayTimeContext Context { get; set; }

        public InvoiceEntityRepository(PlayTimeContext context)
        {
            Context = context;
        }

        public DbSet<Invoice> Table
        {
            get
            {
                return Context.InvoiceSet;
            }
        }

        public DbQuery<Invoice> JoinedTable
        {
            get
            {
                return Context.InvoiceSet.Include("Customer").Include("Project").Include("Tasks");
            }
        }
    }
}
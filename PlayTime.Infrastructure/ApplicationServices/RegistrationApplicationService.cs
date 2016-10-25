namespace PlayTime.Infrastructure.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Models;

    public class RegistrationApplicationService : IRegistrationApplicationService
    {
        private IRegistrationDomainService RegistrationDomainService { get; set; }

        public RegistrationApplicationService(IRegistrationDomainService registrationDomainService)
        {
            RegistrationDomainService = registrationDomainService;
        }

        public Registration Get(Guid id)
        {
            return RegistrationDomainService.Get(id);
        }

        public IEnumerable<Registration> All()
        {
            return RegistrationDomainService.All();
        }

        public IEnumerable<Registration> All(string userId)
        {
            return RegistrationDomainService.All(userId);
        }

        public Registration Create(string note, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced)
        {
            return RegistrationDomainService.Create(note, userId, taskId, startTime, endTime, isInvoiced);
        }

        public void Update(Guid id, string note, bool isDeactivated, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced)
        {
            RegistrationDomainService.Update(id, note, isDeactivated, userId, taskId, startTime, endTime, isInvoiced);
        }
    }
}
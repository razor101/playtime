namespace PlayTime.Infrastructure.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Interfaces.Repository;
    using PlayTime.Infrastructure.Models;

    public class RegistrationDomainService : IRegistrationDomainService
    {
        private IRegistrationRepository RegistrationRepository { get; set; }

        public RegistrationDomainService(IRegistrationRepository registrationRepository)
        {
            RegistrationRepository = registrationRepository;
        }

        public Registration Get(Guid id)
        {
            return new Registration(RegistrationRepository.Get(id));
        }

        public IEnumerable<Registration> All()
        {
            return RegistrationRepository.All().ToList().Select(x => new Registration(x));
        }

        public IEnumerable<Registration> All(string userId)
        {
            return RegistrationRepository.All(userId).ToList().Select(x => new Registration(x));
        }

        public Registration Create(string note, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced)
        {
            return new Registration(RegistrationRepository.Create(note, userId, taskId, startTime, endTime, isInvoiced));
        }

        public void Update(Guid id, string note, bool isDeactivated, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced)
        {
            RegistrationRepository.Update(id, note, isDeactivated, userId, taskId, startTime, endTime, isInvoiced);
        }
    }
}
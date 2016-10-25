namespace PlayTime.Infrastructure.Models
{
    using System;

    public class Registration
    {
        public Guid Id { get; set; }

        public string Note { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Guid TaskId { get; set; }

        public Task Task { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsInvoiced { get; set; }

        public Registration(Data.Models.Registration registration)
        {
            Id = registration.Id;
            Note = registration.Note;
            IsDeactivated = registration.IsDeactivated;
            CreatedDate = registration.CreatedDate;
            LastModifiedDate = registration.LastModifiedDate;

            UserId = registration.UserId;
            if (registration.User != null)
            {
                User = new User(registration.User);
            }

            TaskId = registration.TaskId;
            if (registration.Task != null)
            {
                Task = new Task(registration.Task);
            }

            StartTime = registration.StartTime;
            EndTime = registration.EndTime;
            IsInvoiced = registration.IsInvoiced;
        }
    }
}
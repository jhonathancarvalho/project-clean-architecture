namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTimeOffset DateCreated { get; protected set; }
        public DateTimeOffset? DateUpdated { get; protected set; }
        public DateTimeOffset? DateDeleted { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTimeOffset.UtcNow;
        }

        public void MarkAsUpdated()
        {
            DateUpdated = DateTimeOffset.UtcNow;
        }

        public void MarkAsDeleted()
        {
            DateDeleted = DateTimeOffset.UtcNow;
        }
    }
}
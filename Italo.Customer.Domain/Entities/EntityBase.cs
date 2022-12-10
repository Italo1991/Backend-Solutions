namespace Italo.Customer.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }

        public abstract bool Validate();
        public abstract void ValidateAndThrow();
    }
}

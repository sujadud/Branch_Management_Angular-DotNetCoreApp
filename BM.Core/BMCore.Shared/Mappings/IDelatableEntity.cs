namespace BMCore.Shared.Mappings
{
    public interface IDelatableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
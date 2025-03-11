namespace ExamCore.Shared.Mappings
{
    public interface IAuditableEntity
    {
        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}

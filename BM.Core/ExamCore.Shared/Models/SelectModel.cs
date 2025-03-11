namespace ExamCore.Shared.Models
{
    public class SelectModel
    {
        public dynamic Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public bool IsDefault { get; set; }
        public dynamic ValueOne { get; set; }
        public dynamic ValueTwo { get; set; }
    }
}
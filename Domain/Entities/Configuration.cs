using Domain.Enums;

namespace Domain.Entities
{
    public class Configuration:Entity
    {
        public required ConfigurationKeys Key { get; set; }
        public required string Value { get; set; }
    }
}

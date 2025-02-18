
namespace Core.Domain.Models.Common
{
    public class Identifier
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public Identifier(int id = default, Guid guid = default)
        {
            Id = id;
            Guid = guid;
        }
    }
}

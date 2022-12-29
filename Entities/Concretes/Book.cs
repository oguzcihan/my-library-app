using Entities.Abstracts;

namespace Entities.Concretes
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public bool Read { get; set; }

        public int CategoryId { get; set; }
    }
}

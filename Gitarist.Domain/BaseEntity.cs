using Amdaris.Domain;

namespace Gitarist.Domain
{
    public class BaseEntity : Entity
    {
        public virtual bool Deleted { get; set; }
        public virtual string Name { get; set; }
        public virtual string ClearUrlName { get; set; }
    }
}

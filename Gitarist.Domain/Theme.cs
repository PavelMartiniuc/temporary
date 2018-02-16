namespace Gitarist.Domain
{
    public class Theme : BaseEntity
    {
        public Theme() {}

        public Theme(string name, string clearUrlName)
        {
            Name = name;
            ClearUrlName = clearUrlName;
        }
    }
}

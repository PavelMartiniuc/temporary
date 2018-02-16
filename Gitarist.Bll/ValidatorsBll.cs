
using Gitarist.Domain;
using System.Linq;


namespace Gitarist.Bll
{
    public class ValidatorsBll<T>  where T : BaseEntity
    {
        private Dal.Dal dal;

        public ValidatorsBll()
        {
            dal = new Dal.Dal();
        }

        public bool IsPropertyUnique(string propertyName, string propertyValue , long entityId)
        {

            var query = dal.Query<T>();

            
            switch(propertyName)
            {
                case "ClearUrlName": 
                    {
                        query = query.Where(x => x.ClearUrlName != null && !x.Deleted && x.ClearUrlName.Trim() == propertyValue.Trim());

                        if (entityId != 0)
                            query = query.Where(x => x.ClearUrlName.Trim() != string.Empty && x.Id != entityId);

                        break;
                    }
                case "Name":
                {
                    if (typeof (T) != typeof (Theme)) return true;

                        query = query.Where(x => !x.Deleted && x.Name.Trim() == propertyValue.Trim());

                        if (entityId != 0)
                            query = query.Where(x => x.Name.Trim() != string.Empty && x.Id != entityId);

                        break;
                    }
            }
            
           
            var result = ! query.Any();
            
            return result;
        }

    }
}

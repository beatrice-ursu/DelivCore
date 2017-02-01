using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivCore.DataLayer.Entities.Core
{
    public static class EntityExtensions
    {
        public static void Defaults(this Entity entity, string currentUser)
        {
            entity.CreatedBy = entity.UpdatedBy = currentUser;
            entity.CreatedOn = (entity.UpdatedOn = DateTime.Now as DateTime?).Value;
            entity.Active = true;
        }

        public static void Defaults(this IEnumerable<Entity> entities, string currentUser)
        {
            foreach (var model in entities)
            {
                model.Defaults(currentUser);
            }
        }
    }
}

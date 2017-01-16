using System;
using System.Collections;
using System.Collections.Generic;

namespace DelivCore.Models.Core
{
    public static class ModelExtensions
    {
        public static void Defaults(this Model model, string currentUser)
        {
            model.CreatedBy = model.UpdatedBy = currentUser;
            model.CreatedOn = model.UpdatedOn = DateTime.Now;
            model.Active = true;
        }

        public static void Defaults(this IEnumerable<Model> models, string currentUser)
        {
            foreach (var model in models)
            {
                model.Defaults(currentUser);
            }
        }
    }
}
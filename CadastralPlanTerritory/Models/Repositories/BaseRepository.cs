using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastralPlanTerritory.Models.Repositories
{
    public class BaseRepository
    {
        protected IEntity FindEntity(string id, List<IEntity> entities)
        {
            foreach (IEntity entity in entities)
            {
                if (entity.Id == id)
                {
                    return entity;
                }
            }
            return null;
        }
        public virtual IEntity FindEntity(string id)
        {
            foreach (List<IEntity> entityList in BaseEntity.List)
            {
                IEntity entity = FindEntity(id, entityList);
                if (entity != null)
                {
                    return entity;
                }
            }
            return null;
        }
    }
}

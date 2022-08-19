using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models
{
    public class BaseEntity : IEntity
    {
        public static List<List<IEntity>> List { get; set; } = 
            new List<List<IEntity>>()
            {
                Bound.List, ObjectRealty.List, Parcel.List, SpatialData.List, Zone.List
            };
        public string Id { get; set; }
        public XmlNode XmlNode { get; set; }
    }
}

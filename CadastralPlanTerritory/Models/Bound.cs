using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models
{
    public class Bound: IEntity
    {
        public static List<IEntity> List { get; set; } = new List<IEntity>();
        public string Id { get; set; }
        public XmlNode XmlNode { get; set; }
    }
}

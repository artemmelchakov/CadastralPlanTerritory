using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models
{
    public interface IEntity
    {
        string Id { get; set; }
        XmlNode XmlNode { get; set; }
    }
}

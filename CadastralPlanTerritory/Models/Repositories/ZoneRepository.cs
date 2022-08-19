using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models.Repositories
{
    public class ZoneRepository: BaseRepository
    {
        public void FindZoneEntitiesInXml(XmlNodeList xmlNodeList, List<IEntity> zoneList)
        {
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (xmlNodeList[i].Name == "zones_and_territories_record")
                {
                    Zone zone = new Zone();
                    zone.XmlNode = xmlNodeList[i];
                    zone.Id = xmlNodeList[i].ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                    zoneList.Add(zone);
                    continue;
                }
                FindZoneEntitiesInXml(xmlNodeList[i].ChildNodes, zoneList);
            }
        }

        public override IEntity FindEntity(string id) => base.FindEntity(id, Zone.List);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models.Repositories
{
    public class ObjectRealtyRepository: BaseRepository
    {
        public void FindObjectRealtyEntitiesInXml(XmlNodeList xmlNodeList, List<IEntity> objectRealtyList)
        {
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if 
                (
                    xmlNodeList[i].Name == "build_record" || xmlNodeList[i].Name == "construction_record"
                )
                {
                    ObjectRealty objectRealty = new ObjectRealty();
                    objectRealty.XmlNode = xmlNodeList[i];
                    objectRealty.Id = xmlNodeList[i].ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText;
                    objectRealty.Type = xmlNodeList[i].Name;
                    objectRealtyList.Add(objectRealty);
                    continue;
                }
                FindObjectRealtyEntitiesInXml(xmlNodeList[i].ChildNodes, objectRealtyList);
            }
        }
        public override IEntity FindEntity(string id) => base.FindEntity(id, ObjectRealty.List);
    }
}

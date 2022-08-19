using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models.Repositories
{
    public class BoundRepository: BaseRepository
    {
        public void FindBoundEntitiesInXml(XmlNodeList xmlNodeList, List<IEntity> boundList)
        {
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (xmlNodeList[i].Name == "municipal_boundary_record")
                {
                    Bound bound = new Bound();
                    bound.XmlNode = xmlNodeList[i];
                    bound.Id = xmlNodeList[i].ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                    boundList.Add(bound);
                    continue;
                }
                FindBoundEntitiesInXml(xmlNodeList[i].ChildNodes, boundList);
            }
        }
        public override IEntity FindEntity(string id) => base.FindEntity(id, Bound.List);
    }
}

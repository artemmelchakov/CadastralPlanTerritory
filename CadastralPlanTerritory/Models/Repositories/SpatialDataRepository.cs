using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CadastralPlanTerritory.Models.Repositories
{
    public class SpatialDataRepository: BaseRepository
    {
        public void FindSpatialDataEntitiesInXml(XmlNodeList xmlNodeList, List<IEntity> spatialDataList)
        {
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (xmlNodeList[i].Name == "spatial_data")
                {
                    SpatialData spatialData = new SpatialData();
                    spatialData.XmlNode = xmlNodeList[i];
                    spatialData.Id = xmlNodeList[i].ChildNodes[0].ChildNodes[0].InnerText;
                    spatialDataList.Add(spatialData);
                    continue;
                }
                FindSpatialDataEntitiesInXml(xmlNodeList[i].ChildNodes, spatialDataList);
            }
        }
        public override IEntity FindEntity(string id) => base.FindEntity(id, SpatialData.List);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CadastralPlanTerritory.Models.Repositories
{
    public class ParcelRepository: BaseRepository
    {
        public void FindParcelEntitiesInXml(XmlNodeList xmlNodeList, List<IEntity> parcelList)
        {
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (xmlNodeList[i].Name == "land_record")
                {
                    Parcel parcel = new Parcel();
                    parcel.XmlNode = xmlNodeList[i];
                    parcel.Id = xmlNodeList[i].ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText;
                    parcelList.Add(parcel);
                    continue;
                }
                FindParcelEntitiesInXml(xmlNodeList[i].ChildNodes, parcelList);
            }
        }
        public override IEntity FindEntity(string id) => base.FindEntity(id, Parcel.List);
    }
}

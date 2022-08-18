using CadastralPlanTerritory.Models;
using CadastralPlanTerritory.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CadastralPlanTerritory
{
    public partial class Form1 : Form
    {
        private XmlElement xmlRoot;

        private ParcelRepository parcelRepository;
        private ObjectRealtyRepository objectRealtyRepository;
        private SpatialDataRepository spatialDataRepository;
        private BoundRepository boundRepository;
        private ZoneRepository zoneRepository;

        TreeNode parcelTreeNode = new TreeNode("Parcel");
        TreeNode objectRealtyTreeNode = new TreeNode("ObjectRealty");
        TreeNode spatialDataTreeNode = new TreeNode("SpatialData");
        TreeNode boundTreeNode = new TreeNode("Bound");
        TreeNode zoneTreeNode = new TreeNode("Zone");

        public Form1()
        {
            InitializeComponent();

            xmlRoot = XmlHelper.GetXmlElement();

            parcelRepository = new ParcelRepository();
            objectRealtyRepository = new ObjectRealtyRepository();
            spatialDataRepository = new SpatialDataRepository();
            boundRepository = new BoundRepository();
            zoneRepository = new ZoneRepository();

            treeView1.Nodes.AddRange
            (
                new TreeNode[] 
                {
                    parcelTreeNode,
                    objectRealtyTreeNode,
                    spatialDataTreeNode,
                    boundTreeNode,
                    zoneTreeNode
                }
            );
        }
        public void FormNodesInTreeView (List<IEntity> entityList, TreeNodeCollection treeNodeCollection)
        {
            foreach (var entity in entityList)
            {
                treeNodeCollection.Add(new TreeNode(entity.Id));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parcelRepository.FindInXml(xmlRoot.ChildNodes, Parcel.GlobalParcelList);
            FormNodesInTreeView(Parcel.GlobalParcelList, parcelTreeNode.Nodes);
            
            objectRealtyRepository.FindInXml(xmlRoot.ChildNodes, ObjectRealty.GlobalObjectRealtyList);
            FormNodesInTreeView(ObjectRealty.GlobalObjectRealtyList, objectRealtyTreeNode.Nodes);
            
            spatialDataRepository.FindInXml(xmlRoot.ChildNodes, SpatialData.GlobalSpatialDataList);
            FormNodesInTreeView(SpatialData.GlobalSpatialDataList, spatialDataTreeNode.Nodes);
            
            boundRepository.FindInXml(xmlRoot.ChildNodes, Bound.GlobalBoundList);
            FormNodesInTreeView(Bound.GlobalBoundList, boundTreeNode.Nodes);
            
            zoneRepository.FindInXml(xmlRoot.ChildNodes, Zone.GlobalZoneList);
            FormNodesInTreeView(Zone.GlobalZoneList, zoneTreeNode.Nodes);
        }
    }
}

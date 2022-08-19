﻿using CadastralPlanTerritory.Models;
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
            treeView1.CheckBoxes = true;
            treeView1.BeforeSelect += new TreeViewCancelEventHandler(TreeView1_BeforeSelect);
        }
        public void GetEntityListInTreeView(List<IEntity> entityList, TreeNodeCollection treeNodeCollection)
        {
            foreach (var entity in entityList)
            {
                treeNodeCollection.Add(new TreeNode(entity.Id));
            }
        }
        public void GetEntityPropertiesInTreeView(XmlNodeList xmlNodeList, TreeNodeCollection treeNodeCollection)
        {
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                TreeNode treeNode = new TreeNode();
                if (xmlNode is XmlText)
                {
                    treeNode.Text = xmlNode.InnerText;
                }   
                else
                {
                    treeNode.Text = xmlNode.Name;
                }
                treeNodeCollection.Add(treeNode);
                GetEntityPropertiesInTreeView(xmlNode.ChildNodes, treeNode.Nodes);
            }
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e) 
        {
            if (e.Node.Parent != null)
            {
                treeView2.Nodes.Clear();
                IEntity entity = null;
                if (e.Node.Parent == parcelTreeNode)
                {
                    entity = parcelRepository.FindEntity(e.Node.Text);
                }
                else if (e.Node.Parent == objectRealtyTreeNode)
                {
                    entity = objectRealtyRepository.FindEntity(e.Node.Text);
                }
                else if (e.Node.Parent == spatialDataTreeNode)
                {
                    entity = spatialDataRepository.FindEntity(e.Node.Text);
                }
                else if (e.Node.Parent == boundTreeNode)
                {
                    entity = boundRepository.FindEntity(e.Node.Text);
                }
                else if (e.Node.Parent == zoneTreeNode)
                {
                    entity = zoneRepository.FindEntity(e.Node.Text);
                }

                if (entity != null && entity.XmlNodeList != null)
                {
                    GetEntityPropertiesInTreeView(entity.XmlNodeList, treeView2.Nodes);
                }                
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parcelRepository.FindParcelEntitiesInXml(xmlRoot.ChildNodes, Parcel.List);
            GetEntityListInTreeView(Parcel.List, parcelTreeNode.Nodes);
            
            objectRealtyRepository.FindObjectRealtyEntitiesInXml(xmlRoot.ChildNodes, ObjectRealty.List);
            GetEntityListInTreeView(ObjectRealty.List, objectRealtyTreeNode.Nodes);
            
            spatialDataRepository.FindSpatialDataEntitiesInXml(xmlRoot.ChildNodes, SpatialData.List);
            GetEntityListInTreeView(SpatialData.List, spatialDataTreeNode.Nodes);
            
            boundRepository.FindBoundEntitiesInXml(xmlRoot.ChildNodes, Bound.List);
            GetEntityListInTreeView(Bound.List, boundTreeNode.Nodes);
            
            zoneRepository.FindZoneEntitiesInXml(xmlRoot.ChildNodes, Zone.List);
            GetEntityListInTreeView(Zone.List, zoneTreeNode.Nodes);
        }
    }
}

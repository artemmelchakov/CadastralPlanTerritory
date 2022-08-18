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
        private ParcelRepository parcelRepository;
        private XmlElement xmlRoot;
        public Form1()
        {
            InitializeComponent();
            xmlRoot = XmlHelper.GetInstance().GetXmlElement();
            parcelRepository = new ParcelRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parcelRepository.FormNodeListInTreeView(xmlRoot.ChildNodes, treeView1.Nodes, "land_record");
        }
    }
}

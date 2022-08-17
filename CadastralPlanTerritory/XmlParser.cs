using System;
using System.Configuration;
using System.Xml;

namespace CadastralPlanTerritory
{
    class XmlHelper
    {
        static private XmlDocument XmlDocument_CadastralPlanTerritory;

        static public XmlDocument GetXmlDocument()
        {
            if (XmlDocument_CadastralPlanTerritory != null)
            {
                return XmlDocument_CadastralPlanTerritory;
            }

            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load
                (
                    ConfigurationManager.AppSettings["xmlDocumentsPath"] +
                    ConfigurationManager.AppSettings["xmlFile_CadastralPlanTerritory"]
                );
            }
            catch (Exception)
            {
                throw;
            }
            XmlDocument_CadastralPlanTerritory = xmlDocument;
            return XmlDocument_CadastralPlanTerritory;
        }

        static public XmlElement GetXmlElement()
        {
            if (XmlDocument_CadastralPlanTerritory == null) GetXmlDocument();
            XmlElement xmlRoot = XmlDocument_CadastralPlanTerritory.DocumentElement;
            return xmlRoot;
        }
    }
}

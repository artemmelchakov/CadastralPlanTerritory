using CadastralPlanTerritory.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;

namespace CadastralPlanTerritory
{
    static class XmlHelper
    {
        private static XmlDocument xmlDocument_CadastralPlanTerritory;
        public static XmlDocument GetXmlDocument()
        {
            if (xmlDocument_CadastralPlanTerritory == null)
            {
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
                xmlDocument_CadastralPlanTerritory = xmlDocument;
            }
            return xmlDocument_CadastralPlanTerritory;
        }
        public static XmlElement GetXmlElement()
        {
            if (xmlDocument_CadastralPlanTerritory == null) GetXmlDocument();
            XmlElement xmlRoot = xmlDocument_CadastralPlanTerritory.DocumentElement;
            return xmlRoot;
        }
        public static void SaveEntitiesInXmlDocument(List<string> idList, Stream stream)
        {
            BaseRepository baseRepository = new BaseRepository(); 

            XmlDocument xmlDocument = new XmlDocument();
            string xmlstring = "";
            foreach (string id in idList)
            {
                xmlstring += baseRepository.FindEntity(id).XmlNode.OuterXml;
            }
            xmlstring =
                "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" +
                "<saved_entities>\n" +
                xmlstring +
                "</saved_entities>\n";
            xmlDocument.LoadXml(xmlstring);

            if (stream != null)
            {
                xmlDocument.Save(stream);
                stream.Close();
            }            
        }
    }
}

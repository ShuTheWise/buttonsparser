using System.Xml;
using System.Collections.Generic;
using System;

public class FntParse
{

    public static void DoXMLPase(string path, List<icon> icons)
    {
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(path);

        XmlNode info = xml.GetElementsByTagName("info")[0];
        XmlNode common = xml.GetElementsByTagName("common")[0];
        XmlNode page = xml.GetElementsByTagName("pages")[0].FirstChild;
        XmlNodeList chars = xml.GetElementsByTagName("chars")[0].ChildNodes;

        foreach (var e in icons)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                XmlNode charNode = chars[i];
                var v = ToInt(charNode, "id");
                if (v == int.Parse(e.id))
                {
                    Console.WriteLine(v);
                  
                    charNode.Attributes.GetNamedItem("x").InnerText = e.x.ToString();
                    charNode.Attributes.GetNamedItem("y").InnerText = e.y.ToString();
                    charNode.Attributes.GetNamedItem("width").InnerText = e.width.ToString();
                    charNode.Attributes.GetNamedItem("height").InnerText = e.height.ToString();
                    charNode.Attributes.GetNamedItem("xadvance").InnerText = e.width.ToString();
                    charNode.Attributes.GetNamedItem("xoffset").InnerText = "0";
                    charNode.Attributes.GetNamedItem("yoffset").InnerText = "0";
                }
            }
        }

        xml.Save(@"c:\temp\result.fnt");
    }
    private static int ToInt(string hex)
    {
        return new int();
    }

    private static int ToInt(XmlNode node, string name)
    {
        return int.Parse(node.Attributes.GetNamedItem(name).InnerText);
    }
}
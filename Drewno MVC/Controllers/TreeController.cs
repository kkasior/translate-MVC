using Drewno_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace Drewno_MVC.Controllers
{
    public class TreeController : Controller
    {
        // GET: Tree
        public ActionResult Index()
        {
            var model = new List<ResourcesFile>();
            XElement doc = XElement.Load(@"C:\Users\Heinrich Himmler\Desktop\programowanie\praktyki\ResourcesResult\ConsoleTranslatorResult.xml");
            List<XElement> fileElemList = doc.Descendants().Where(w => w.Name == "File").ToList();
            for (int k = 0; k < fileElemList.Count(); k++)
            {
                var newNode = new ResourcesFile { file = fileElemList[k].Value };
                List<XElement> TranslateElemList = doc.Descendants().Where(w => w.Name == "Translation" && w.Attribute("Key").Value.Contains("DM."+ newNode.file)).ToList();
                for (int j = 0; j < TranslateElemList.Count; j++)
                {
                    XElement translation = TranslateElemList[j];
                    var newKey = new ResourcesKey {
                        key = translation.Attribute("Key").Value,
                        En = translation.Descendants().First(f => f.Name == "value" && f.Attribute("Lang").Value.Trim() == "EN").Value,
                        OtherLanguages = translation.Descendants().Where(f => f.Name == "value" && f.Attribute("Lang").Value.Trim() != "EN").Select(s => new ResourcesOtherLanguages { Key = s.Attribute("Lang").Value, Value = s.Value }).ToList()
                    };

                    newNode.Keys.Add(newKey); 
                }
                
                model.Add(newNode);                
            }
            return View(model);
        }
    }
}
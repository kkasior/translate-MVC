using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drewno_MVC.Models
{
    public class Resources
    {
        public string root { get; set; }
        public string file { get; set; }
        public string key { get; set; }
        public string englishValue { get; set; }
        public string otherValue { get; set; }
    }

    public class ResourcesFile
    {
        public ResourcesFile()
        {
            Keys = new List<ResourcesKey>();
        }
        public string file { get; set; }

        public List<ResourcesKey> Keys { get; set; }
    }

    public class ResourcesKey
    {
        public ResourcesKey()
        {
            OtherLanguages = new List<ResourcesOtherLanguages>();
        }
        public string key { get; set; }
        public string En { get; set; }
        public List<ResourcesOtherLanguages> OtherLanguages { get; set; }
        
    }
    public class ResourcesOtherLanguages
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Submit { get; set; }
    }

}
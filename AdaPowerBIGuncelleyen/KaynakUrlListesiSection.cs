using System.Configuration;

namespace AdaPowerBIGuncelleyen
{
    public class KaynakListesiSection : ConfigurationSection
    {
        [ConfigurationProperty("KaynakUrlListesi")]
        public KaynakUrlCollection KaynakUrlItems
        {
            get { return ((KaynakUrlCollection)(base["KaynakUrlListesi"])); }
        }

    }

    [ConfigurationCollection(typeof(KaynakUrlElement))]
    public class KaynakUrlCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new KaynakUrlElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((KaynakUrlElement)(element)).Url;
        }
        public KaynakUrlElement this[int idx]
        {
            get { return (KaynakUrlElement)BaseGet(idx); }
        }
    }

    public class KaynakUrlElement : ConfigurationElement
    {
        [ConfigurationProperty("ad", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Ad
        {
            get { return ((string)(base["ad"])); }
            set { base["ad"] = value; }
        }

        [ConfigurationProperty("url", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Url
        {
            get { return ((string)(base["url"])); }
            set { base["url"] = value; }
        }

        public override string ToString()
        {
            return Ad;
        }
    }
}

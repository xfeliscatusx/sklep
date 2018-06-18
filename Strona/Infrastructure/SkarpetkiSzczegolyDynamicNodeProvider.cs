using MvcSiteMapProvider;
using Strona.DataAccessLayer;
using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strona.Infrastructure
{
    public class SkarpetkiSzczegolyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private SkarpetkiContext db = new SkarpetkiContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach(Skarpetki skarpetki in db.Skarpetki)
            {
                DynamicNode node = new DynamicNode();
                node.Title = skarpetki.NazwaSkarpetek;
                node.Key = "Skarpetki_" + skarpetki.SkarpetkiId;
                node.ParentKey = "Kategoria_" + skarpetki.KategoriaId;
                node.RouteValues.Add("id", skarpetki.SkarpetkiId);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanuageFeaturesOwn.Models;

namespace LanuageFeaturesOwn.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ??"<No Name>";
                decimal? price = p?.Price ?? 0; // Prüfung auf null-Werte
                string relatedName = p?.Related?.Name ?? "<None>"; //null-Werte entdecken null conditional operator später in Kombination mit coalescing operator
                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
            }
            return View(results);
        }
    }
}

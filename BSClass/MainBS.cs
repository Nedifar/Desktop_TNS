using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BSClass
{
    public class MainBS
    {
        static bool hand = false;
        private static async Task<string> ras(int i)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync($@"http://localhost:62727/api/basestation/{i}").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private static async Task<ActionResult<double>> modding(BaseStation mod, double R0, Raion raion)
        {
            if (mod.idBaseStation != 3 && mod.idBaseStation != 4)
            {
                mod.radius = Math.Sqrt(mod.area / Math.PI);
                if (raion.typeBuild == "Плотная городская застройка")
                {
                    using (var http = new HttpClient())
                    {
                        double l = 1.21 * Math.Pow(R0 * Math.Sqrt(mod.area / Math.PI), 2);
                        var f = await ras(mod.idBaseStation).ConfigureAwait(false);
                        if (Convert.ToInt32(f) < mod.begin)
                        {
                            hand = true;
                        }
                        L += l;
                    }
                }
                else if (raion.typeBuild == "Средняя городская застройка")
                {
                    var http = new HttpClient();
                    double l = 0.9 * Math.Pow(R0 * Math.Sqrt(mod.area / Math.PI), 2);
                    var response = await http.GetAsync($@"http://localhost:62727/api/basestation/{mod.idBaseStation}").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var f = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
                    if (f < mod.begin)
                    {
                        hand = true;
                    }
                    if (f > mod.end)
                    {
                        return new NotFoundObjectResult(null);
                    }
                    L += l;
                }
            }
        }

        private async static Task<double> mainRaschet(Raion raion)
        {
            double L = 0;
            double R0 = Math.Sqrt(raion.area / Math.PI);
            foreach (var mod in context.aGetContext().BaseStations.OrderByDescending(p=>p.area).ToList())
            {
                var response = await modding(mod, R0, raion);
                L += response.Value;
            }
            L = L / context.aGetContext().BaseStations.Count();
            context.aGetContext().SaveChanges();
            List<BaseStation> bases = context.aGetContext().BaseStations.ToList();
            Random rnd = new Random();
            double d1 = 0;
            double d2 = 0;
            double d3 = 0;
            while(!(d1> d2 && d1>d3 && d2>d3 && d3!=0 && d2!=0 && d1!=0))
            {
                d1 = bases[rnd.Next(bases.Count())].radius * 2;
                d2 = bases[rnd.Next(bases.Count())].radius * 2;
                d3 = bases[rnd.Next(bases.Count())].radius * 2;
            }
            double c = Math.Pow(d1, 2.5) + Math.Pow(d2, 1.5) + Math.Pow(d3, 0.5);
            double n = 0;
            if (!hand)
            {
                n = L * c;
            }
            else
            {
                n = L * c*1.4;
            }
            return n;
        }
        public static void poRaionam()
        {
            foreach(var mod in context.aGetContext().Raions.ToList())
            {
                Console.WriteLine(mod.name + " " + mainRaschet(mod).Result);
            }
        }
        public static void AllRaions()
        {
            double n = 0;
            foreach (var mod in context.aGetContext().Raions.ToList())
            {
                n = mainRaschet(mod).Result;
            }
            Console.WriteLine(n);
        }
    }
}

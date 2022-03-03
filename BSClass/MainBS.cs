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
        public static async Task<string> ras(int i)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync($@"http://localhost:62727/api/basestation/{i}").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch
            { return "В настоящий момент сервер недоступен, пожалуйста повторите попытку позднее"; }
        }

        public static async Task<ActionResult<string>> modding(BaseStation mod, double R0, Raion raion)
        {
            if (R0 <= 0)
            {
                return new NotFoundObjectResult("Радиус не может быть меньше нуля");
            }
            else
            {
                if ((mod.idBaseStation != 3 || mod.idBaseStation != 4) && mod.idBaseStation < 9)
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
                            if (Convert.ToInt32(f) > mod.end)
                            {
                                return new NotFoundObjectResult("Показания хэндовера превышают допустимые");
                            }
                            return l.ToString();
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
                            return new NotFoundObjectResult("Показания хэндовера превышают допустимые");
                        }
                        return l.ToString();
                    }
                    else
                    {
                        return new NotFoundObjectResult("Тип постройки не найден");
                    }
                }
                else
                    return new NotFoundObjectResult("Не найдена базовая станция с указанным id");
            }
        }

        public async static Task<ActionResult<string>> mainRaschet(Raion raion)
        {
            if (raion.area > 0)
            {
                double L = 0;
                double R0 = Math.Sqrt(raion.area / Math.PI);
                foreach (var mod in context.aGetContext().BaseStations.OrderByDescending(p => p.area).ToList())
                {
                    var response = await modding(mod, R0, raion);
                    var result = Convert.ToDouble(response.Value);
                    L += result;
                }
                L = L / context.aGetContext().BaseStations.Count();
                context.aGetContext().SaveChanges();
                List<BaseStation> bases = context.aGetContext().BaseStations.ToList();
                Random rnd = new Random();
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;
                while (!(d1 > d2 && d1 > d3 && d2 > d3 && d3 != 0 && d2 != 0 && d1 != 0))
                {
                    d1 = bases[rnd.Next(bases.Count())].radius * 2;
                    d2 = bases[rnd.Next(bases.Count())].radius * 2;
                    d3 = bases[rnd.Next(bases.Count())].radius * 2;
                }
                double c = Math.Pow(d1, 2.5) + Math.Pow(d2, 1.5) + Math.Pow(d3, 0.5);
                var res = Convert.ToDouble(getN(L, c, hand).Result.Value);
                return res.ToString();
            }
            else
                return new NotFoundObjectResult("Радиус района не может быть меньше нуля");

        }

        public async static Task<ActionResult<string>> getN(double L, double c, bool hand)
        {
            if(L<=0)
            {
                return new NotFoundObjectResult("Соты не могут равняться нулю, проверьте правильность введенных данных");
            }
            if(c<=0)
            {
                return new NotFoundObjectResult("Количество базовых станций в одном кластере не может равняться нулю");
            }
            double n = 0;
            if (!hand)
            {
                n = L * c;
            }
            else
            {
                return new NotFoundObjectResult("Показания одной из базовых станций низкое, поэтому конечное количество базовых станций будет умножено на 1.4");
                n = L * c * 1.4;
            }
            return n.ToString();
        }
        public static string poRaionam()
        {
            try
            {
                foreach (var mod in context.aGetContext().Raions.ToList())
                {
                    Console.WriteLine(mod.name + " " + mainRaschet(mod).Result);
                }
                return "good";
            }
            catch { return "Ошибка в подключении к базе данных"; }
        }
        public static void AllRaions()
        {
            double n = 0;
            foreach (var mod in context.aGetContext().Raions.ToList())
            {
                n = Convert.ToDouble(mainRaschet(mod).Result);
            }
            Console.WriteLine(n);
        }
    }
}

//Jaka Pozun
//NALOGA 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga5
{
    public enum Prednosti { wifi, tv, klima, parkirisce, bazen };
    class Program
    {
        static void Main(string[] args)
        {
            //PRIMERI
            /*
            Potnik potnik1 = new Potnik("Jaka", "Pozun", Oseba.Spol.moski, new DateTime(1998, 4, 26), "jaka.pozun@gmail.com", Oseba.Status.student);
            Console.WriteLine(potnik1.MojIzpis());

            Potnik potnik2 = new Potnik("Miha", "Pozun", Oseba.Spol.moski, new DateTime(1998, 5, 20), "miha.pozun@gmail.com", Oseba.Status.upokojenec);
            Console.WriteLine(potnik2.MojIzpis());

            Avtobus avtobus1 = new Avtobus("bus", "BUS", 14, 100, 45, 0, 10);
            Console.WriteLine(avtobus1.MojIzpis());

            Termin prvi_termin = new Termin(new DateTime(2018, 8, 8), new DateTime(2018, 9, 9), avtobus1, potnik1);

            Izlet prvi_izlet = new Izlet("Izlet", 100, "Velenje", prvi_termin);

            prvi_izlet.ProdajKarto(prvi_termin, potnik1);
            prvi_izlet.ProdajKarto(prvi_termin, potnik2);

            prvi_izlet.PrekliciKarto(prvi_termin, potnik1);

            Console.WriteLine("Mesto prosto: " + prvi_izlet.MestoProsto(prvi_termin));

            prvi_izlet.IzracunajCeno(potnik2);
            */

            Potnik popotnik1 = new Potnik("Matjaž", "Lah", Oseba.Spol.moski, new DateTime(1994, 4, 4), "matjaz@email.com", Oseba.Status.student);
            Potnik popotnik2 = new Potnik("Gorana", "Sladic", Oseba.Spol.zenska, new DateTime(2003, 4, 4), "gorana@email.com", Oseba.Status.otrok);
            Potnik popotnik3 = new Potnik("Klemen", "Novak", Oseba.Spol.moski, new DateTime(1950, 4, 4), "klemen@email.com", Oseba.Status.upokojenec);

            Voznik voznik1 = new Voznik("Tilen", "Pelko", Oseba.Spol.moski, new DateTime(1998, 5, 5), new DateTime(2019, 1, 1));

            Avtobus avtobus1 = new Avtobus("Mercedes", "GH-d44", 20, 110, 50, 0, 0);

            Dictionary<string, Potnik> potniki = new Dictionary<string, Potnik>();
            List<Termin> termini = new List<Termin>();

            Termin termin1 = new Termin(new DateTime(2018, 8, 8), new DateTime(2018, 9, 9), avtobus1, potniki);
            Termin termin2 = new Termin(new DateTime(2020, 6, 6), new DateTime(2020, 6, 16), avtobus1, potniki);

            Izlet izlet1 = new Izlet("Potovanje po Evropi", 450, "Maribor", termini);

            izlet1.DodajTermin(termin1);
            izlet1.OdstraniTermin(termin1);
            izlet1.DodajTermin(termin1);
            izlet1.DodajTermin(termin2);

            Console.WriteLine("Najkasnejsi termin: " + izlet1.VrniNajkasnejsiTermin().datum_cas_odhoda);

            izlet1.ProdajKarto(termin1, popotnik1);
            izlet1.ProdajKarto(termin1, popotnik2);
            izlet1.ProdajKarto(termin1, popotnik3);

            izlet1.PrekliciKarto(termin1, popotnik2);

            izlet1.IzracunajCeno(popotnik3);

            Console.WriteLine("Mesto prosto:" + izlet1.MestoProsto(termin1));

            Console.WriteLine("Poisci potnika: " + izlet1.NajdiPotnika("matjaz@email.com", termin1).MojIzpis());

            izlet1.PregledPrijavljenih(termin1);

            
            Console.ReadKey();
        }
    }
}

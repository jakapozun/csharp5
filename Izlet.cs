using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga5
{
    public class Izlet : IProdajni
    {
        public string naziv;
        public double cena_izleta;
        public string kraj_odhoda;

        public List<Termin> polje = new List<Termin>();

        public Izlet()
        {

        }

        public Izlet(string naziv, double cena_izleta, string kraj_odhoda, List<Termin> polje)
        {
            this.naziv = naziv;
            this.cena_izleta = cena_izleta;
            this.kraj_odhoda = kraj_odhoda;
            this.polje = polje;
        }

        public void ProdajKarto(Termin termin, Potnik potnik)
        {
            for (int i = 0; i < polje.Count; i++)
            {
                if (termin.Equals(polje[i]))
                {
                    polje[i].PoljePotnikov.Add(potnik.email, potnik);

                    Console.WriteLine("Dodali ste potnika.");
                }

            }

        }
        public double IzracunajCeno(Potnik potnik)
        {
            double cena;

            if (potnik.status == Oseba.Status.upokojenec)
            {
                cena = (cena_izleta * 0.9);
                Console.WriteLine("Cena izleta je " + cena + "eu.");
            }
            else if (potnik.status == Oseba.Status.student)
            {
                cena = (cena_izleta * 0.85);
                Console.WriteLine("Cena izleta je " + cena + "eu.");
            }
            else
            {
                cena = cena_izleta;
                Console.WriteLine("Cena izleta je " + cena + "eu.");
            }

            return cena;

        }

        public bool MestoProsto(Termin termin)
        {
            if (termin.PoljePotnikov.Count < termin.avtobus.stevilo_sedezev)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public void PrekliciKarto(Termin termin, Potnik potnik)
        {
            for (int i = 0; i < polje.Count; i++)
            {
                if (termin.Equals(polje[i]))
                {
                    bool preklic = polje[i].PoljePotnikov.Remove(potnik.email);

                    if (preklic == true)
                    {
                        Console.WriteLine("Odtranili ste potnika.");
                    }

                    else
                    {
                        Console.WriteLine("Napaka");
                    }
                }
            }
        }


        public void PregledPrijavljenih(Termin termin)
        {
            for (int i = 0; i < polje.Count; i++)
            {
                if (termin.Equals(polje[i]))
                {
                    Console.WriteLine("Potniki v terminu: " + termin.datum_cas_odhoda);
                    for (int j = 1; j < polje[i].PoljePotnikov.Count; j++)
                    {
                        foreach (KeyValuePair<string, Potnik> entry in polje[i].PoljePotnikov)
                        {
                            Console.WriteLine(entry.Value.ime + " " + entry.Value.priimek + ", " + entry.Value.email);                           
                        }
                    }
                }
            }

        }

        public void DodajTermin(Termin termin)
        {
            polje.Add(termin);
            Console.WriteLine("Dodali ste termin.");
        }

        public void OdstraniTermin(Termin termin)
        {
            bool odstrani = polje.Remove(termin);

            if (odstrani == true)
            {
                Console.WriteLine("Odstranili ste termin.");
            }

            else
            {
                Console.WriteLine("Napaka!");
            }
        }

        public Termin VrniNajkasnejsiTermin()
        {
            Termin najkasnejsi = new Termin();

            for (int i = 0; i < polje.Count; i++)
            {
                if (polje[i].datum_cas_odhoda > najkasnejsi.datum_cas_odhoda)
                {
                    najkasnejsi = polje[i];
                }
            }

            return najkasnejsi;
        }

        public Potnik NajdiPotnika(string email, Termin termin)
        {
            Potnik p = new Potnik();

            if (polje.Contains(termin))
            {
                for (int i = 0; i < polje.Count; i++)
                {
                    if (termin.Equals(polje[i]))
                    {
                        if (polje[i].PoljePotnikov.ContainsKey(email))
                        {
                            return polje[i].PoljePotnikov[email];
                        }

                        else
                        {
                            return p;
                        }
                    }
                }

                return p;
            }

            else
            {
                return p;
            }

        }
    }
}


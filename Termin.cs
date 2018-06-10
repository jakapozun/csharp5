using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga5
{
    public class Termin
    {
        public DateTime datum_cas_odhoda;
        public DateTime datum_cas_prihoda;
        public Avtobus avtobus;

        Dictionary<string, Potnik> poljePotnikov;

        public Dictionary<string, Potnik> PoljePotnikov
        {
            get
            {
                return poljePotnikov;
            }

            set
            {
                poljePotnikov = value;
            }
        }
        public Termin()
        {

        }

        public Termin(DateTime datum_cas_odhoda, DateTime datum_cas_prihoda, Avtobus avtobus, Dictionary<string, Potnik> poljePotnikov)
        {
            this.datum_cas_odhoda = datum_cas_odhoda;
            this.datum_cas_prihoda = datum_cas_prihoda;
            this.avtobus = avtobus;
            this.poljePotnikov = poljePotnikov;
        }
    }
}

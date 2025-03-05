using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asdfgh
{
    public class Gra
    {
        public string Nazwa { get; set; }
        public int max_graczy { get; set; }
        public int min_graczy { get; set; }
        public int ile_grano { get; set; }

        public List<string> komentarz = new List<string>();

        public Gra(string nazwa, int max_graczy, int min_graczy, int ile_grano)
        {
            Nazwa = nazwa;
            this.max_graczy = max_graczy;
            this.min_graczy = min_graczy;
            this.ile_grano = ile_grano;
        }
    }
}

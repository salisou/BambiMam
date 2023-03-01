using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace BambiMam.Models
{
    public class Registrazioni
    {
        [PrimaryKey, NotNull, AutoIncrement]
        public int N_Pannolini { get; set; }
        public string Pipi { get; set; }
        public string Colori_Cacca { get; set; }

        public string name { get; set; }
        public DateTime Data_Inserimento { get; set; }
        
        public TimeSpan Ore { get; set; }
    }
}

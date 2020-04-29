using System;

namespace LibrarieModele
{
    public class PersoaneContact
    {
        int NUME = 0;
        int PRENUME = 1;
        int NUMARTEL = 2;
        int ADRESAMAIL = 3;
        int GRUPP = 4;
        string SEPARATOR_FISIER = " ";
       
       


        public Grup GRUP { get; set; }
        public string Nume { set; get; }
        public string Prenume { set; get; }
        public string NumarTelefon { set; get; }
        public string AdresaEmail { set; get; }

        public DateTime DataNasterii { set; get; }
        public string NumeleComplet { get { return Nume + " " + Prenume; } }


        public PersoaneContact()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            NumarTelefon = string.Empty;
            AdresaEmail = string.Empty;
            GRUP = Grup.NonGrup;




        }
        /// <summary>
        /// Constructor cu parametri
        /// </summary>
        /// <param name="numePersoana"></param>
        /// <param name="nrTel"></param>
        /// <param name="e_mail"></param>
        public PersoaneContact(string numePersoana, string prenumePers, string nrTel, string e_mail, int _grup)
        {
            this.Nume = numePersoana;
            this.Prenume = prenumePers;
            this.NumarTelefon = nrTel;
            this.AdresaEmail = e_mail;
            this.GRUP = (Grup)_grup;




        }
        /// <summary>
        /// Constructor care primeste un sir de caractere
        /// </summary>
        /// <param name="pers1"></param>
        public PersoaneContact(string pers1)
        {
            string[] buff = pers1.Split();
            Nume = buff[NUME];
            Prenume = buff[PRENUME];
            NumarTelefon = buff[NUMARTEL];
            AdresaEmail = buff[ADRESAMAIL];
            GRUP = (Grup)Convert.ToInt32(buff[GRUPP]);
            //Enum.TryParse(buff[GRUPP], out GRUP);

        }





        // Afisare date despre contact
        public string ConversieLaSir()
        {

            return string.Format("Persoana de contact are numele " + Nume + " " + Prenume + " cu numarul de telefon: " + NumarTelefon + "  adresa de e-mail: " + AdresaEmail + " din grupul " + GRUP);

        }
        public string nastere()
        {
            return "Data nasterii: " + DataNasterii;

        }
        public bool Compara(PersoaneContact c)
        {
            if (this.NumeleComplet.Length > c.NumeleComplet.Length)
            {
                return true;
            }
            return false;

        }

        /*public string ToString()
        {
            return Nume + " " + Prenume + " face parte din grupul: " + GRUP;
        }*/

        public string ConversieLaSir_PentruFisier()
        {
            string TEL = string.Empty;
            TEL = string.Join(SEPARATOR_FISIER, NumarTelefon);
            string date = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}", SEPARATOR_FISIER, Nume, Prenume, TEL, AdresaEmail,Convert.ToInt32( GRUP));

            return date;
        }

    }
}


﻿using LibrarieModele;
using System;
using System.Collections;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierBinar implementeaza interfata IStocareData
    public class AdministrarePersoaneContact_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrarePersoaneContact_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddPersoana(PersoaneContact s)
        {
            throw new Exception("Optiunea AddStudent nu este implementata");
        }

        public ArrayList GetPersoane()
        {
            throw new Exception("Optiunea GetStudenti nu este implementata");
        }

        public PersoaneContact GetPersoane(string nume, string prenume)//, string numar, string mail)
        {
            throw new Exception("Optiunea GetStudent nu este implementata");
        }

        public bool UpdatePersoana(PersoaneContact s)
        {
            throw new Exception("Optiunea UpdateStudent nu este implementata");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;
using System.Collections;

namespace PersoaneContact_WFROM
{
    public partial class Form1 : Form
    {
        IStocareData adminPersoane;
        public Form1()
        {
            
            InitializeComponent();
            adminPersoane = StocareFactory.GetAdministratorStocare();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            PersoaneContact s;
            txtNumarTelefon.ForeColor = Color.Black;
            txtNume.ForeColor = Color.Black;
            txtPrenume.ForeColor = Color.Black;
            txtMail.ForeColor = Color.Black;
            txtGrup.ForeColor = Color.Black;
            CodEroare valideaza = Validare(txtNume.Text, txtPrenume.Text, txtNumarTelefon.Text, txtMail.Text);
            if (valideaza != CodEroare.CORECT)
            {
                switch (valideaza)
                {
                    case CodEroare.NUME_INCORECT:
                        txtNume.ForeColor = Color.Red;
                        break;
                    case CodEroare.PRENUME_INCORECT:
                        txtPrenume.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUMAR_INCORECTE:
                        txtNumarTelefon.ForeColor = Color.Red;
                        break;
                    case CodEroare.MAIL_INCORECT:
                        txtMail.ForeColor = Color.Red;
                        break;
                }
            }
            else
            {
                s = new PersoaneContact(txtNume.Text, txtPrenume.Text, txtNumarTelefon.Text, txtMail.Text,Convert.ToInt32(txtGrup.Text));
                adminPersoane.AddPersoana(s);

                lblAdauga.Text = "Contactul a fost adaugat";
            }


        }
        private CodEroare Validare(string nume, string prenume, string numar, string mail)
        {
            if (nume == string.Empty)
            {
                return CodEroare.NUME_INCORECT;
            }
            if (prenume == string.Empty)
            {
                return CodEroare.PRENUME_INCORECT;
            }
            if (numar == string.Empty)
            {
                return CodEroare.NUMAR_INCORECTE;
            }
            if (mail == string.Empty)
            {
                return CodEroare.MAIL_INCORECT;
            }
            return CodEroare.CORECT;
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            rtbAfisare.Clear();
            ArrayList persoane = adminPersoane.GetPersoane();
            foreach (PersoaneContact s in persoane)
            {
               
                rtbAfisare.AppendText(s.NumeleComplet);
                rtbAfisare.AppendText(Environment.NewLine);
            }
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            PersoaneContact s = adminPersoane.GetPersoane(txtNume.Text, txtPrenume.Text);//, txtNumarTelefon.Text, txtMail.Text);
            if (s != null)
            {
                lblCauta.Text = s.ConversieLaSir();
            }
            else
                lblCauta.Text = "Nu s-a gasit Persoana de contact";
            if (txtNume.Enabled == true && txtPrenume.Enabled == true)
            {
                txtNume.Enabled = false;
                txtPrenume.Enabled = false;
            }
            else
            {
                txtNume.Enabled = true;
                txtPrenume.Enabled = true;
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            PersoaneContact s = adminPersoane.GetPersoane(txtNume.Text, txtPrenume.Text);
            if (s != null)
            {

                
                
                    //adminPersoane.UpdatePersoana(s);
                    lblModifica.Text = "Modificare efectuata cu succes";
                    txtNume.Enabled = true;
                    txtPrenume.Enabled = true;
                


            }
            else
            {
                lblModifica.Text = "Contact inexistent";
            }

        }
    }
}

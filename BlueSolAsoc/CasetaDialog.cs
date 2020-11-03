using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CasetaDialogTag.CasetaDialog;

namespace CasetaDialogTag
{
    public partial class CasetaDialog : Form
    {
        string titlu;
        string mesaj;
        ButonMesaj butonMesaj1;
        ButonMesaj butonMesaj2;
        ButonMesaj butonMesaj3;
        IconitaMesaj iconitaMesaj;

        public enum IconitaMesaj
        {
            Niciuna,
            Intrebare,
            Informare,
            Avertizare,
            Eroare
        }

        public enum ButonMesaj
        {
            Nimic,
            Ok,
            Anuleaza,
            Abandoneaza,
            Reincearca,
            Ignora,
            Da,
            Nu

        }
      

        private void CasetaDialog_Load(object sender, EventArgs e)
        {
            lblTitlu.Text = titlu;
            lblMesaj.Text = mesaj;
            switch (iconitaMesaj)
            {
                case IconitaMesaj.Niciuna:
                    BoxIconitaMesaj.Visible = false;
                    break;
                case IconitaMesaj.Intrebare:
                    BoxIconitaMesaj.Image = BlueSolAsoc.Properties.Resources.intrebare;
                    break;
                case IconitaMesaj.Informare:
                    BoxIconitaMesaj.Image = BlueSolAsoc.Properties.Resources.informare;
                    break;
                case IconitaMesaj.Avertizare:
                    BoxIconitaMesaj.Image = BlueSolAsoc.Properties.Resources.avertizare;
                    break;
                case IconitaMesaj.Eroare:
                    BoxIconitaMesaj.Image = BlueSolAsoc.Properties.Resources.eroare;
                    break;
                default:
                    break;
            }

            switch (butonMesaj1)
            {
                case ButonMesaj.Nimic:
                    btnPrimar.Visible = false;
                    break;
                case ButonMesaj.Ok:
                    btnPrimar.Text = "OK";
                    break;
                case ButonMesaj.Anuleaza:
                    btnPrimar.Text = "Anuleaza";
                    break;
                case ButonMesaj.Abandoneaza:
                    btnPrimar.Text = "Abandoneaza";
                    break;
                case ButonMesaj.Reincearca:
                    btnPrimar.Text = "Reincearca";
                    break;
                case ButonMesaj.Ignora:
                    btnPrimar.Text = "Ignora";
                    break;
                case ButonMesaj.Da:
                    btnPrimar.Text = "Da";
                    break;
                case ButonMesaj.Nu:
                    btnPrimar.Text = "Nu";
                    break;
            }
            switch (butonMesaj2)
            {
                case ButonMesaj.Nimic:
                    btnSecundar.Visible = false;
                    break;
                case ButonMesaj.Ok:
                    btnSecundar.Text = "OK";
                    break;
                case ButonMesaj.Anuleaza:
                    btnSecundar.Text = "Anuleaza";
                    break;
                case ButonMesaj.Abandoneaza:
                    btnSecundar.Text = "Abandoneaza";
                    break;
                case ButonMesaj.Reincearca:
                    btnSecundar.Text = "Reincearca";
                    break;
                case ButonMesaj.Ignora:
                    btnSecundar.Text = "Ignora";
                    break;
                case ButonMesaj.Da:
                    btnSecundar.Text = "Da";
                    break;
                case ButonMesaj.Nu:
                    btnSecundar.Text = "Nu";
                    break;
            }
            switch (butonMesaj3)
            {
                case ButonMesaj.Nimic:
                    btnFinal.Visible = false;
                    break;
                case ButonMesaj.Ok:
                    btnFinal.Text = "OK";
                    break;
                case ButonMesaj.Anuleaza:
                    btnFinal.Text = "Anuleaza";
                    break;
                case ButonMesaj.Abandoneaza:
                    btnFinal.Text = "Abandoneaza";
                    break;
                case ButonMesaj.Reincearca:
                    btnFinal.Text = "Reincearca";
                    break;
                case ButonMesaj.Ignora:
                    btnFinal.Text = "Ignora";
                    break;
                case ButonMesaj.Da:
                    btnFinal.Text = "Da";
                    break;
                case ButonMesaj.Nu:
                    btnFinal.Text = "Nu";
                    break;
            }






        }

        public CasetaDialog()
        {
            InitializeComponent();
           
            btnPrimar.Text = "OK";
            btnSecundar.Visible = false;
            btnFinal.Visible = false;
        }
        public CasetaDialog(string Titlu)
        {
            InitializeComponent();
            titlu = Titlu;
            btnPrimar.Text = "OK";
            btnSecundar.Visible = false;
            btnFinal.Visible = false;
        }

        public CasetaDialog(string Titlu, ButonMesaj Buton_Mesaj1, IconitaMesaj niciuna)
        {
            InitializeComponent();
            titlu = Titlu;
            butonMesaj1 = Buton_Mesaj1;
            btnSecundar.Visible = false;
            btnFinal.Visible = false;          
        }
        public CasetaDialog(string Titlu, string Mesaj, ButonMesaj Buton_Mesaj1, IconitaMesaj niciuna)
        {
            InitializeComponent();
            titlu = Titlu;
            butonMesaj1 = Buton_Mesaj1;
            btnSecundar.Visible = false;
            btnFinal.Visible = false;
            mesaj = Mesaj;

        }
        public CasetaDialog(string Titlu, string Mesaj, ButonMesaj Buton_Mesaj1, ButonMesaj Buton_Mesaj2, IconitaMesaj Iconita_Mesaj)
        {
            InitializeComponent();
            titlu = Titlu;
            mesaj = Mesaj;
            butonMesaj1 = Buton_Mesaj1;
            butonMesaj2 = Buton_Mesaj2;
            btnFinal.Visible = false;
            iconitaMesaj = Iconita_Mesaj;

        }
        public CasetaDialog(string Titlu, string Mesaj, ButonMesaj Buton_Mesaj1, ButonMesaj Buton_Mesaj2, ButonMesaj Buton_Mesaj3, IconitaMesaj Iconita_Mesaj)
        {
            InitializeComponent();
            titlu = Titlu;
            mesaj = Mesaj;
            butonMesaj1 = Buton_Mesaj1;
            butonMesaj2 = Buton_Mesaj2;
            butonMesaj3 = Buton_Mesaj3;
            iconitaMesaj = Iconita_Mesaj;
        }

        public static System.Windows.Forms.DialogResult AfiseazaMesaj(string DialogTitlu )
        {
            using (CasetaDialog casetaDialog = new CasetaDialog(DialogTitlu,  ButonMesaj.Ok, IconitaMesaj.Niciuna))
            {
                casetaDialog.ShowDialog();
                return casetaDialog.DialogResult;
            }

        }
        public static System.Windows.Forms.DialogResult AfiseazaMesaj(string DialogTitlu, string DialogMesaj)
        {
            using (CasetaDialog casetaDialog = new CasetaDialog(DialogTitlu, DialogMesaj, ButonMesaj.Ok, IconitaMesaj.Niciuna))
            {
                casetaDialog.ShowDialog();
                return casetaDialog.DialogResult;
            }

        }
        public static System.Windows.Forms.DialogResult AfiseazaMesaj(string DialogTitlu, string DialogMesaj, ButonMesaj DialogButon)
        {
            using (CasetaDialog casetaDialog = new CasetaDialog(DialogTitlu, DialogMesaj, DialogButon, IconitaMesaj.Niciuna))
            {
                casetaDialog.ShowDialog();
                return casetaDialog.DialogResult;
            }

        }
        public static System.Windows.Forms.DialogResult AfiseazaMesaj(string DialogTitlu, string DialogMesaj, ButonMesaj DialogButon, IconitaMesaj DialogIconita)
        {
            using (CasetaDialog casetaDialog = new CasetaDialog(DialogTitlu, DialogMesaj, DialogButon, DialogIconita))
            {
                casetaDialog.ShowDialog();
                return casetaDialog.DialogResult;
            }

        }
        public static System.Windows.Forms.DialogResult AfiseazaMesaj(string DialogTitlu, string DialogMesaj, ButonMesaj DialogButon1, ButonMesaj DialogButon2, IconitaMesaj DialogIconita)
        {
            using (CasetaDialog casetaDialog = new CasetaDialog(DialogTitlu, DialogMesaj, DialogButon1, DialogButon2, DialogIconita))
            {
                casetaDialog.ShowDialog();
                return casetaDialog.DialogResult;
            }

        }
        public static System.Windows.Forms.DialogResult AfiseazaMesaj(string DialogTitlu, string DialogMesaj, ButonMesaj DialogButon1, ButonMesaj DialogButon2, ButonMesaj DialogButon3, IconitaMesaj DialogIconita)
        {
            using (CasetaDialog casetaDialog = new CasetaDialog(DialogTitlu, DialogMesaj, DialogButon1, DialogButon2, DialogButon3, DialogIconita))
            {
                casetaDialog.ShowDialog();
                return casetaDialog.DialogResult;
            }

        }
        //actiuni buton1
        private void btnPrimar_Click(object sender, EventArgs e)
        {
            switch (butonMesaj1)
            {
                case ButonMesaj.Nimic:
                    DialogResult = DialogResult.None;
                    break;
                case ButonMesaj.Ok:
                    DialogResult = DialogResult.OK;
                    break;
                case ButonMesaj.Anuleaza:
                    DialogResult = DialogResult.Cancel;
                    break;
                case ButonMesaj.Abandoneaza:
                    DialogResult = DialogResult.Abort;
                    break;
                case ButonMesaj.Reincearca:
                    DialogResult = DialogResult.Retry;
                    break;
                case ButonMesaj.Ignora:
                    DialogResult = DialogResult.Ignore;
                    break;
                case ButonMesaj.Da:
                    DialogResult = DialogResult.Yes;
                    break;
                case ButonMesaj.Nu:
                    DialogResult = DialogResult.No;
                    break;
                default:
                    break;
            }


        }
        //actiuni buton2
        private void btnSecundar_Click(object sender, EventArgs e)
        {
            switch (butonMesaj2)
            {
                case ButonMesaj.Nimic:
                    DialogResult = DialogResult.None;
                    break;
                case ButonMesaj.Ok:
                    DialogResult = DialogResult.OK;
                    break;
                case ButonMesaj.Anuleaza:
                    DialogResult = DialogResult.Cancel;
                    break;
                case ButonMesaj.Abandoneaza:
                    DialogResult = DialogResult.Abort;
                    break;
                case ButonMesaj.Reincearca:
                    DialogResult = DialogResult.Retry;
                    break;
                case ButonMesaj.Ignora:
                    DialogResult = DialogResult.Ignore;
                    break;
                case ButonMesaj.Da:
                    DialogResult = DialogResult.Yes;
                    break;
                case ButonMesaj.Nu:
                    DialogResult = DialogResult.No;
                    break;
                default:
                    break;
            }

        }
        //actiuni buton3
        private void btnFinal_Click(object sender, EventArgs e)
        {
            switch (butonMesaj3)
            {
                case ButonMesaj.Nimic:
                    DialogResult = DialogResult.None;
                    break;
                case ButonMesaj.Ok:
                    DialogResult = DialogResult.OK;
                    break;
                case ButonMesaj.Anuleaza:
                    DialogResult = DialogResult.Cancel;
                    break;
                case ButonMesaj.Abandoneaza:
                    DialogResult = DialogResult.Abort;
                    break;
                case ButonMesaj.Reincearca:
                    DialogResult = DialogResult.Retry;
                    break;
                case ButonMesaj.Ignora:
                    DialogResult = DialogResult.Ignore;
                    break;
                case ButonMesaj.Da:
                    DialogResult = DialogResult.Yes;
                    break;
                case ButonMesaj.Nu:
                    DialogResult = DialogResult.No;
                    break;
                default:
                    break;
            }
        }
    }
}

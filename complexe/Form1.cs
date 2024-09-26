using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace complexe
{
    public partial class Form1 : Form
    {
        OpenFileDialog d1 = new OpenFileDialog();
        Image photo1;
        List<maison> lm = new List<maison>();
        int pos = 0;
        public void nav()
        {
            code.Text = lm[pos].Code.ToString();
            superficier.Text = lm[pos].Superficier.ToString();
            style.Text = lm[pos].Style;
            nom.Text = lm[pos].Nom_locataire;
            montant.Text = lm[pos].Montant_loyer.ToString();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[pos].Selected = true;
        }
       
        public int chercher(int code)
        {
            for(int i=0;i<lm.Count;i++)
            {
                if(lm[i].Code==code)
                {
                    return i;
                }
            }
            return -1;
        }

        public void vider()
        {
            code.Clear();
            superficier.Clear();
            style.SelectedIndex = 0;
            nom.Clear();
            montant.Clear();
        }
        public void actualiser()
        {

            dataGridView1.Rows.Clear();
            foreach(maison m in lm)
            {
                dataGridView1.Rows.Add(m.Photo,m.Code, m.Superficier, m.Style, m.Nom_locataire, m.Montant_loyer);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            style.Items.Add("aire+1");
            style.Items.Add("aire+2");
            style.Items.Add("aire+3");
            style.SelectedIndex = 0;

            //dataGridView1.Columns.Add("code", "Code");
            //dataGridView1.Columns.Add("superficier", "Superficier");
            //dataGridView1.Columns.Add("style", "Style");
            //dataGridView1.Columns.Add("nom", "Nom Locataire");
            //dataGridView1.Columns.Add("montant", "Montant Loyer");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(code.Text!="" && superficier.Text!="" && nom.Text!="" && montant.Text!="")
            {
                int r = chercher(int.Parse(code.Text));
                if (r == -1)
                {
                    maison m = new maison(photo1,int.Parse(code.Text), double.Parse(superficier.Text), style.Text, nom.Text, double.Parse(montant.Text));
                    lm.Add(m);
                    actualiser();
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[lm.Count-1].Selected = true;
                    vider();
                }
                else
                {
                    MessageBox.Show("cette maison est existe deja dans la complexe!!");
                }
            }
            else
            {
                MessageBox.Show("vous devez respecter les champs!!");
            }
           
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = chercher(int.Parse(code.Text));
            if (r != -1)
            {
                superficier.Text = lm[r].Superficier.ToString();
                style.Text=lm[r].Style;
                nom.Text = lm[r].Nom_locataire;
                montant.Text = lm[r].Montant_loyer.ToString();

                dataGridView1.ClearSelection();
                dataGridView1.Rows[r].Selected = true;
                vider();

            }
            else
            {
                MessageBox.Show("la maison n'existe pas dans la complexe!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (code.Text != "" && superficier.Text != "" && nom.Text != "" && montant.Text != "")
            {
                int r = chercher(int.Parse(code.Text));
                if(r!=-1)
                {
                    lm[r].Superficier = double.Parse(superficier.Text);
                    lm[r].Style = style.Text;
                    lm[r].Nom_locataire = nom.Text;
                    lm[r].Montant_loyer = double.Parse(montant.Text);
                    actualiser();
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[r].Selected = true;
                }
                else
                {
                    MessageBox.Show("ce code la n'existe pas!!");
                }
            }
            else
            {
                MessageBox.Show("vous devez respecter les champs!!");
            }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = chercher(int.Parse(code.Text));
            if (r != -1)
            {
                lm.RemoveAt(r);
                actualiser();
            }
            else
            {
                MessageBox.Show("la maison n'existe pas!!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pos = 0;
            nav();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pos = lm.Count - 1;
            nav();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos--;
            }
            else
            {
                pos = lm.Count - 1;
            }
            nav();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pos < lm.Count - 1)
            {
                pos++;
            }
            else
            {
                pos = 0;
            }
            nav();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            d1.Title = "choisir une photo";
            d1.InitialDirectory = @"c:/";
            d1.FileName = "photo";
            d1.Filter = "jpg images|*.jpg";
            d1.ShowDialog();
            photo1 = Image.FromFile(d1.FileName);

        }
    }
}

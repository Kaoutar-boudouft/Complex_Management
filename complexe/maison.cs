using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complexe
{
    class maison
    {
        Image photo;
        int code;
        double superficier;
        string style;
        string nom_locataire;
        double montant_loyer;

        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public double Superficier
        {
            get { return superficier; }
            set { superficier = value; }
        }

        public string Style
        {
            get { return style; }
            set { style = value; }
        }

        public string Nom_locataire
        {
            get { return nom_locataire; }
            set { nom_locataire = value; }
        }

        public double Montant_loyer
        {
            get { return montant_loyer; }
            set { montant_loyer = value; }
        }

        public maison(Image photo,int code,double superficier,string style,string nom_locataire,double montant_loyer)
        {
            this.photo = photo;
            this.code = code;
            this.superficier = superficier;
            this.style = style;
            this.nom_locataire = nom_locataire;
            this.montant_loyer = montant_loyer;
        }
    }
}

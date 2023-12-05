using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace calculatriceStandard
{
    public partial class Calculatrice : Form
    {           
        // Variables pour stocker les valeurs et résultats des opérations

        private decimal valueFirst= 0.0m;
        private decimal valueSecond = 0.0m;
        private decimal Result= 0.0m;

        // Opérateur en cours d'utilisation

        private string operateur;

        // Initialisation du formulaire

        public Calculatrice()
        {
            InitializeComponent();
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            // Si le champ texte est vide ou affiche le résultat, mettez "0", sinon ajoutez "0"

            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "0";
            }
            else
            {
                // Si le champ texte commence par zéro ou - 0, n'ajoute pas de zéro supplémentaire

                if (!TxtBox.Text.StartsWith("0") && !TxtBox.Text.StartsWith("-0"))
                    TxtBox.Text += "0";
            }

        }
        private void dotBtn_Click(object sender, EventArgs e)
        {
            // Si le champ texte ne contient pas déjà une virgule et n'est pas vide, ajoutez une virgule

            if (!TxtBox.Text.Contains(",") && TxtBox.Text!="")
            {
                TxtBox.Text += ",";
            }
        }

        private void unBtn_Click(object sender, EventArgs e)
        {
            // Gère l'affichage après le clic sur un bouton si
            //TxtBox.Text == "0" ou si TxtBox.Text == Result
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "1";
            }
            else
            {
                TxtBox.Text += "1";
            }
        }
        private void deuxBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "2";
            }
            else
            {
                TxtBox.Text += "2";
            }
        }

        private void troisBtn_Click(object sender, EventArgs e)
        {
            //Gere l'affichage apres click sur un bouton
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "3";
            }
            else
            {
                TxtBox.Text += "3";
            }
        }

        private void quatreBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" )
            {
                TxtBox.Text = "4";
            }
            else
            {
                TxtBox.Text += "4";
            }
        }

        private void cinqBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "5";
            }
            else
            {
                TxtBox.Text += "5";
            }
        }

        private void sixBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "6";
            }
            else
            {
                TxtBox.Text += "6";
            }
        }

        private void septBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "7";
            }
            else
            {
                TxtBox.Text += "7";
            }
        }

        private void huitBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "8";
            }
            else
            {
                TxtBox.Text += "8";
            }
        }

        private void neufBtn_Click(object sender, EventArgs e)
        {
            if (TxtBox.Text == "0" || TxtBox.Text == Result.ToString())
            {
                TxtBox.Text = "9";
            }
            else
            {
                TxtBox.Text += "9";
            }
        }
        

        private void plusMoinsBtn_Click(object sender, EventArgs e)
        {
            // Vérifie si le texte contient un signe négatif
            if (TxtBox.Text.Contains("-"))
            {
                { 
                    TxtBox.Text = TxtBox.Text.Trim('-');
                }
            }
            else
            {
                // Ajoute le signe négatif au début du texte
                TxtBox.Text = "-" + TxtBox.Text;
            }
        }
    


        private void plusBtn_Click(object sender, EventArgs e)
        {
            if (Result==0.0m)
            {
                valueFirst = decimal.Parse(TxtBox.Text);
                
            }
            else
            {
                valueFirst = Result;
            }
            TxtBox.Text = "0";
            operateur = "+";

        }

        private void moinsBtn_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(TxtBox.Text);
            TxtBox.Text = "0";
            operateur = "-";
        }

        private void multiplierBtn_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(TxtBox.Text);
            TxtBox.Text = "0";
            operateur = "x";
        }

        private void diviserBtn_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(TxtBox.Text);
            TxtBox.Text = "0";
            operateur = "/";
        }
        private void moduloBtn_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(TxtBox.Text);
            TxtBox.Text = "0";
            operateur = "%";
        }
        private void egalBtn_Click(object sender, EventArgs e)
        {
            switch (operateur)
            {
                case "+":
                    valueSecond = decimal.Parse(TxtBox.Text);
                    Result = valueFirst + valueSecond;
                    TxtBox.Text = Result.ToString();
                    
                break;

                case "-":
                    valueSecond = decimal.Parse(TxtBox.Text);
                    Result = valueFirst - valueSecond;
                    TxtBox.Text = Result.ToString();
                    valueFirst = Result;

                break;

                case "x":
                    valueSecond = decimal.Parse(TxtBox.Text);
                    Result = valueFirst * valueSecond;
                    TxtBox.Text = Result.ToString();
                    valueFirst = Result;
                break;

                case "/":
                    valueSecond = decimal.Parse(TxtBox.Text);
                    // Vérifier la division par zéro
                    if (valueSecond != 0)
                    {
                        Result = valueFirst / valueSecond;
                        TxtBox.Text = Result.ToString();
                        valueFirst = Result;
                    }
                    else
                    {
                        MessageBox.Show("Impossible de diviser un nombre par zero.");
                        TxtBox.Text = "0";
                    }
                break;

                case "%":
                    valueSecond = decimal.Parse(TxtBox.Text);
                    if (valueSecond != 0)
                    {
                        Result = valueFirst % valueSecond;
                        TxtBox.Text = Result.ToString();
                        valueFirst = Result;
                    }
                    else
                    {
                        MessageBox.Show("Impossible de diviser un nombre par zero.");
                        TxtBox.Text = "0";
                    }
                break;
            }



        }

        private void delBtn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtBox.Text))
            {
                // Utiliser la méthode Substring pour obtenir une sous-chaîne sans le dernier caractère
                TxtBox.Text = TxtBox.Text.Substring(0, TxtBox.Text.Length - 1);
            }

        }

        //Vider le cache
        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Réinitialiser les variables
            valueFirst = 0.0m;
            valueSecond = 0.0m;
            operateur ="";

            // Effacer le TextBox
            TxtBox.Text = "0";
        }

       
    }
}

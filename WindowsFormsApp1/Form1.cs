using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Identity : Form
    {
        public Identity()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e) //Kör själva beräkningen vid klickning.
        {
            label6.Text = "Resultat:"; //Skriver ut "Resultat" i den dolda rutan.
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string pNumber = textBox3.Text;
            if (pNumber.Length == 13) //Kontrollerar så att formatet är korrekt, annars får man felmeddelande.
            { //Här startar beräkningarna så att man i slutändan får ut ett giltigt personnummer.
                int a0 = pNumber[2] - 48; //Eftersom pNumber[] är en string så får jag ta talet - 0 för att få rätt sluttal. Ex; "2" - "0" = 50- 48 = 2.
                int a1 = pNumber[3] - 48;
                int a2 = pNumber[4] - 48;
                int a3 = pNumber[5] - 48;
                int a4 = pNumber[6] - 48;
                int a5 = pNumber[7] - 48;
                int a6 = pNumber[9] - 48;
                int a7 = pNumber[10] - 48;
                int a8 = pNumber[11] - 48;
                int a9 = pNumber[12] - 48;
                //Eftersom det endast är värdet på a0, a6 och a8 som kan överstiga 10 så räcker det att köra nedanstående för dem.
                if (a0 * 2 >= 10)
                {
                    string a01 = (a0 * 2).ToString(); //Konverterar det multiplicerade talet till en string.
                    a0 = a01[0] + a01[1] - 96; //Lägger ihop char 1 och 2 till en summa - 2*"0".
                }
                else
                {
                    a0 = a0 * 2; //Multiplicera med 2.
                }
                if (a6 * 2 >= 10)
                {
                    string a61 = (a6 * 2).ToString();
                    a6 = a61[0] + a61[1] - 96;
                }
                else
                {
                    a6 = a6 * 2;
                }
                if (a8 * 2 >= 10)
                {
                    string a81 = (a8 * 2).ToString();
                    a8 = a81[0] + a81[1] - 96;
                }
                else
                {
                    a8 = a8 * 2;
                }
                double value0 = a0 + a1 + a3 + a5 + a6 + a7 + a8 + a9 + ((a2 + a4) * 2); //Beräknar summan av samtliga deltal.
                int p = pNumber[11] - 48; //Könskontroll!
                char y1 = pNumber[0]; //Millenium.
                char y2 = pNumber[1]; //Sekel.
                char y3 = pNumber[2]; //Decennium.
                char y4 = pNumber[3]; //År.
                double d = value0 / 10; //Bara en förenkling av value0.

                if ((d == 1) || (d == 2) || (d == 3) || (d == 4) || (d == 5) || (d == 6) || (d == 7)) //Om d är ett heltal, kör på! Annars felmeddelande.
                {

                    if ((p == 1) || (p == 3) || (p == 5) || (p == 7) || (p == 9)) //Könskontroll för udda siffror.
                    { //Skriver ut texten i den nedersta rutan.
                        richTextBox1.Text = ("Förnamn: " + fname + "\n" + "Efternamn: " + lname + "\n" + "Juridiskt kön: Man" + "\n" + "Födelseår: " + y1 + y2 + y3 + y4);
                    }
                    else //Jämn siffra = Kvinna
                    { //Skriver ut texten i den nedersta rutan.
                        richTextBox1.Text = ("Förnamn: " + fname + "\n" + "Efternamn: " + lname + "\n" + "Juridiskt kön: Kvinna" + "\n" + "Födelseår: " + y1 + y2 + y3 + y4);
                    }
                }
                else //Felmeddelande
                {
                    richTextBox1.Text = ("Felaktigt personnummer!" + "\n" + "Försök igen!");
                }

            }
            else //Felmeddelande
            {
                richTextBox1.Text = ("Felaktigt personnummer!" + "\n" + "Försök igen!");
            }
        }
        private void button2_Click(object sender, EventArgs e) //Stänger programmet.
        {
            this.Close();
        }
    }
}
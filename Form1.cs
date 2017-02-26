using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Poczotki
{
    public partial class Form1 : Form
    {
        private void mov_average(List<Structure> Dat)
        {
            double sum = 0;
            for (int i = 0; i < Dat.Count; i++)
            {
                sum += Dat[i].close;
                if (i < 15)
                {
                    Dat[i].moving_average = sum / (i + 1);
                    continue;
                }
                sum -= Dat[i - 15].close;
                Dat[i].moving_average = sum / 15;

            }
        }
        private List<Structure> Data;
        public Form1()
        {
            InitializeComponent();
            Data = new List<Structure>();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            Read.Enabled = false;

            StreamReader sr = File.OpenText("plik.txt");
            string s = String.Empty;
            s = sr.ReadLine();                          ///wczytuje linijke opisowa
            while ((s = sr.ReadLine()) != null)
            {
                Structure tmp = new Structure(s);

                Data.Add(tmp);
            }
            //Read.Enabled = true;
        }

        private void Display_Click(object sender, EventArgs e)
        {
            mov_average(Data);
            for (int i = 0; i < 10; i++)
            {
                FileData.Text += Data[i].moving_average + "\n";
            }
        }

        private void Write_Click(object sender, EventArgs e) {
            string filename = "WIG20_";
           

                if (!File.Exists(fn)) {

                }
            }

            FileData.Text = "OK";
            StreamWriter sw = new StreamWriter(filename); 
        }
        private string set_file_name(string prefix) {
            bool exist = true; 
            int name = 1;
            while (exist) {
                string fn = String.Empty;
                if (name < 10) {
                    fn = filename + "00" + Convert.ToString(name) + ".txt";
                }
                else if (name < 100) {
                    fn = filename + "0" + Convert.ToString(name) + ".txt";
                }
                else {
                    fn = filename + Convert.ToString(name) + ".txt";
                }
        }
    }

    class Structure
    {
        public string name;
        double date;
        double open;
        double high;
        double low;
        public double close;
        double volume;

        public double moving_average;

        public Structure(string line)
        {
            string[] tab = line.Split(new char[] { ',' });

            name = tab[0];
            date = Double.Parse(tab[1], System.Globalization.CultureInfo.InvariantCulture);
            open = Double.Parse(tab[2], System.Globalization.CultureInfo.InvariantCulture);
            high = Double.Parse(tab[3], System.Globalization.CultureInfo.InvariantCulture);
            low = Double.Parse(tab[4], System.Globalization.CultureInfo.InvariantCulture);
            close = Double.Parse(tab[5], System.Globalization.CultureInfo.InvariantCulture);
            volume = Double.Parse(tab[6], System.Globalization.CultureInfo.InvariantCulture);
        }

    }
}

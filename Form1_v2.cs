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

namespace Gielda
{
    public partial class Form1 : Form
    {
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
            mov_average(Data); 
        }

        private void mov_average(List<Structure> Dat)
        {
            double sum = 0;
            for (int i = 0; i < Dat.Count; i++)
            {
                sum += Dat[i].close;
                if (i < 15)
                {
                    Dat[i].moving_average = sum / (i + 1);
                    Dat[i].all_data += "," + Convert.ToString(sum / (i + 1));    ///dopisanie tekstu do danych (ulatwia zapis pliku)
                    continue;
                }
                sum -= Dat[i - 15].close;
                Dat[i].moving_average = sum / 15;

                Dat[i].all_data += "," + Convert.ToString(sum / 15);        ///dopisanie tekstu do danych (ulatwia zapis pliku)
            }
        }
        private string set_file_name(string prefix) {
            FileData.Text = String.Empty;
            int name = 1;
            while (true) {
                string fn = String.Empty;
                if (name < 10) {
                    fn = prefix + "00" + Convert.ToString(name) + ".txt";
                }
                else if (name < 100) {
                    fn = prefix + "0" + Convert.ToString(name) + ".txt";
                }
                else {
                    fn = prefix + Convert.ToString(name) + ".txt";
                }
                if (!File.Exists(fn)) {
                    return fn;
                }
                name++;
                FileData.Text += fn + '\n';
            }   
        }

        private void Display_Click(object sender, EventArgs e)
        {

        }

        private void Write_Click(object sender, EventArgs e)
        {
            string filename = set_file_name("WIG20_");

            FileData.Text += filename + '\n';
            StreamWriter sw = new StreamWriter(filename);

            sw.WriteLine("Name,Date,Open,High,Low,Close,Volume,Mov_Average");
            for (int i = 0; i < Data.Count; i++)
            {
                sw.WriteLine(Data[i].all_data);
            }
        }

    }
    class Structure
    {
        public string name;
        public double date;
        public double open;
        public double high;
        public double low;
        public double close;
        public double volume;

        public double moving_average;

        public string all_data;

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

            all_data = line;
        }
    }
}

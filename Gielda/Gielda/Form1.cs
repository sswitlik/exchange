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
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.SetItemChecked(0, true);        //NA STARCIE WYSWIETLAJ DWA WYKRESY
            ListBox.SetItemChecked(1, true);        //

            //TESTOWANIE
            //Read_Click(sender, e);
            //Display_Click(sender, e);
        }

        private void Read_Click(object sender, EventArgs e)
        {
            Read.Enabled = false;

            if (Data.Count == 0)
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    StreamReader sr = File.OpenText(openFileDialog1.FileName);
                    var s = String.Empty;
                    s = sr.ReadLine();                          //wczytuje pierwsza linijke (opisowa)
                    while ((s = sr.ReadLine()) != null)
                    {
                        Structure tmp = new Structure(s);
                        Data.Add(tmp);
                    }
                    mov_average(Data, 15);
                }
            }
            Display_Click(sender, e);

            Read.Enabled = true;
        }

        private void Display_Click(object sender, EventArgs e)
        {
            ListBox.Visible = true;
            chart.Series.Clear();
            //SWIECOWY
            if (ListBox.GetItemChecked(0))
            {
                chart.Series.Add("candle");
                chart.Series["candle"].ChartType = SeriesChartType.Candlestick;
                chart.Series["candle"].Color = Color.RoyalBlue;
                for (int i = 0; i < Data.Count; i++)
                {
                    double[] point = new double[4] { Data[i].high, Data[i].low, Data[i].open, Data[i].close };

                    chart.Series["candle"].Points.AddXY(DateTime.ParseExact(Data[i].date, "yyyyMMdd", CultureInfo.InvariantCulture), Data[i].high);

                    chart.Series["candle"].Points[i].YValues[1] = Data[i].low;
                    chart.Series["candle"].Points[i].YValues[2] = Data[i].open;
                    chart.Series["candle"].Points[i].YValues[3] = Data[i].close;
                }
            }
            //LINIOWY
            if (ListBox.GetItemChecked(1))
            {
                chart.Series.Add("mov_average");
                chart.Series["mov_average"].ChartType = SeriesChartType.Line;
                chart.Series["mov_average"].Color = Color.Gold;
                for (int i = 0; i < Data.Count; i++)
                {
                    chart.Series["mov_average"].Points.AddXY(DateTime.ParseExact(Data[i].date, "yyyyMMdd", CultureInfo.InvariantCulture), Data[i].moving_average);
                }
            }
        }

        private void Write_Click(object sender, EventArgs e)
        {
            string filename = set_file_name("WIG20_");

            FileData.Text += filename + '\n';           
            var sw = new StreamWriter(filename);

            sw.WriteLine("Name,Date,Open,High,Low,Close,Volume,Mov_Average_15");
            for (int i = 0; i < Data.Count; i++)
            {
                sw.WriteLine(Data[i].all_data);
            }
        }

        private void mov_average(List<Structure> Dat, int part)
        {
            double sum = 0;
            for (int i = 0; i < Dat.Count; i++)
            {
                sum += Dat[i].close;
                if (i < part)
                {
                    Dat[i].moving_average = sum / (i + 1);
                    Dat[i].all_data += "," + Convert.ToString(sum / (i + 1));    //dopisanie tekstu do danych (ulatwia zapis pliku)
                }
                else
                {
                    sum -= Dat[i - part].close;
                    Dat[i].moving_average = sum / part;
                    Dat[i].all_data += "," + Convert.ToString(sum / part);        //dopisanie tekstu do danych (ulatwia zapis pliku)
                }
            }
        }

        private string set_file_name(string prefix)
        {
            FileData.Text = String.Empty;
            int name = 1;
            while (true)
            {
                string fn = String.Empty;
                if (name < 10)
                    fn = prefix + "00" + Convert.ToString(name) + ".txt";
                else if (name < 100)
                    fn = prefix + "0" + Convert.ToString(name) + ".txt";
                else
                    fn = prefix + Convert.ToString(name) + ".txt";
                if (!File.Exists(fn))
                    return fn;
                name++;
                FileData.Text += fn + '\n';
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Display_Click(sender, e);
        }

    }
    class Structure
    {
        public string name;
        public string date;
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
            date = tab[1];
            open = Double.Parse(tab[2], System.Globalization.CultureInfo.InvariantCulture);
            high = Double.Parse(tab[3], System.Globalization.CultureInfo.InvariantCulture);
            low = Double.Parse(tab[4], System.Globalization.CultureInfo.InvariantCulture);
            close = Double.Parse(tab[5], System.Globalization.CultureInfo.InvariantCulture);
            volume = Double.Parse(tab[6], System.Globalization.CultureInfo.InvariantCulture);

            all_data = line;
        }
    }
}

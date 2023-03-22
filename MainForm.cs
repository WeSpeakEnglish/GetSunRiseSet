/*
 * Created by SharpDevelop.
 * User: PineLab
 * Date: 12.07.2014
 * Time: 14:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GetSunRiseSet
{

	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		SunUtil SunCalculations = new SunUtil();
		int timerBehaviour = 0;
		public double JD = 0;
        public int zone = +4; // Seattle time Zone
        public double latitude = 55.75; // Seattle lat
        public double longitude = 37.50; // Seattle lon 
        public bool dst = false; // Day Light Savings 
        public DateTime date = DateTime.Today;		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			
			
			InitializeComponent();
			
			//INI Sun Calculator
		//	SunCalculations.
		    textBox1.Text = latitude.ToString();
			textBox2.Text = longitude.ToString();
			dateTimePicker1.Value = new DateTime( DateTime.Now.Year, 1, 1, 0, 0, 0 );
			dateTimePicker2.Value = new DateTime( DateTime.Now.Year, 12, 31, 0, 0, 0 );
			comboBox1.SelectedIndex = comboBox1.Items.IndexOf("N");
			comboBox2.SelectedIndex = comboBox2.Items.IndexOf("E");
			numericUpDown1.Text="4";
			//dateTimePicker1.Value. = 1;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if(checkBox1.Checked) dst = true;
			else dst = false;
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			
		}
		
		void DateTimePicker2ValueChanged(object sender, EventArgs e)
		{
			
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void DomainUpDown1SelectedItemChanged(object sender, EventArgs e)
		{
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
		string LatS = textBox1.Text.ToString();
		LatS = LatS.Replace(",", ".");
           double.TryParse(LatS,out latitude);//LatS);
           
           latitude += 0.01;
           textBox1.Text = latitude.ToString();
        //   timer1.Start();
           
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
		//	if(button2.KeyDown.) {
        //   SunCalculations.latitude += 0.01;
        //   textBox1.Text = SunCalculations.latitude.ToString();			
		//	}
		//	else etimer1.Stop();
		switch(timerBehaviour){
			case 1: 
	//					   SunCalculations.latitude += 0.01;
    //                     textBox1.Text = SunCalculations.latitude.ToString();
				break;
		
		}
		}
		
		void Button2KeyDown(object sender, KeyEventArgs e)
		{
	//	   SunCalculations.latitude += 0.01;
  //         textBox1.Text = SunCalculations.latitude.ToString();
    //       timerBehaviour =1;
    //       timer1.Start();
		}
		
		void Button2KeyUp(object sender, KeyEventArgs e)
		{
	//	timer1.Stop();	
		}
		
		void Button3Click(object sender, EventArgs e)
		{
		string LatS = textBox1.Text.ToString();
		LatS = LatS.Replace(",", ".");
           double.TryParse(LatS,out latitude);//LatS);
           
           latitude -= 0.01;
           textBox1.Text = latitude.ToString();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
		string LongS = textBox2.Text.ToString();
		LongS = LongS.Replace(",", ".");
           double.TryParse(LongS,out longitude);//LatS);
           
           longitude += 0.01;
           textBox2.Text = longitude.ToString();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
		string LongS = textBox2.Text.ToString();
		LongS = LongS.Replace(",", ".");
           double.TryParse(LongS,out longitude);//LatSlongitude);
           
           longitude -= 0.01;
           textBox2.Text = longitude.ToString();		
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			DateTime DateS1 = dateTimePicker1.Value;
			DateTime DateS2 = dateTimePicker2.Value;
			string[] toList = new string[3];
			double sunRise;
			double sunSet;
			
			date = DateS1;
			
			
			double.TryParse(textBox1.Text.ToString(),out latitude);
			double.TryParse(textBox2.Text.ToString(),out longitude);
		
			dataGridView1.Columns.Clear();
			//DateS.Ticks = DateS.Ticks + 1000;//AddDays(100000);//.AddDays(1.0);
			dataGridView1.Columns.Add("Date","Date");
			dataGridView1.Columns.Add("SunRise","Sunrise");
			dataGridView1.Columns.Add("SunSet","Sunset");
			dataGridView1.Columns.Add("SunRiseMin","Sunrise Min.");
			dataGridView1.Columns.Add("SunSetMin","Sunset Min.");
			dataGridView1.Rows.Clear();
			while(DateS1.CompareTo(DateS2) <= 0){
				//dateTimePicker1.Value = DateS1;
				date = DateS1;

            JD = SunCalculations.calcJD(date);  //OR   JD = Util.calcJD(2014, 6, 1);
            sunRise = SunCalculations.calcSunRiseUTC(JD, latitude, longitude);
            sunSet = SunCalculations.calcSunSetUTC(JD, latitude, longitude);
           // date.ToShortDateString
           int a = date.ToString().Length;
           dataGridView1.Rows.Add(date.Day.ToString() + '.' + date.Month.ToString() + '.' + date.Year.ToString(),
                                  							SunCalculations.getTimeString(false,sunRise, zone, JD, dst),
                                  							SunCalculations.getTimeString(false,sunSet, zone, JD, dst),
                                  						    SunCalculations.getTimeString(true,sunRise, zone, JD, dst),
                                  						    SunCalculations.getTimeString(true,sunSet, zone, JD, dst)
                                  						);//(date.Tostring);
        
				DateS1 = DateS1.AddDays(1.0);  //.Now.AddSeconds( 10 );
		
			}
		}
		
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			int.TryParse(numericUpDown1.Value.ToString(),out zone);
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			
		}
		
		void DateTimePicker1ValueChanged(object sender, EventArgs e)
		{
			
		}
		
		void Label4Click(object sender, EventArgs e)
		{
			
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == comboBox1.Items.IndexOf("S")) latitude = -latitude;
		}
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == comboBox1.Items.IndexOf("W"))longitude = -longitude;
		}
		
		void NumericUpDown1Enter(object sender, EventArgs e)
		{
			
		}
	}
}

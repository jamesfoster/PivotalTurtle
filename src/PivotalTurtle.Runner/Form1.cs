using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PivotalTurtle.Runner
{
	public partial class Form1 : Form
	{
		public Plugin Plugin { get; set; }

		public Form1(Plugin plugin)
		{
			Plugin = plugin;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string bugIdOut;
			string[] revPropNames;
			string[] revPropValues;

			var newMessage = Plugin.GetCommitMessage2(
				default(IntPtr), 
				"", 
				"", 
				"", 
				new string[0],
				textBox1.Text, 
				"", 
				out bugIdOut,
				out revPropNames,
				out revPropValues);

			textBox1.Text = newMessage;
		}
	}
}

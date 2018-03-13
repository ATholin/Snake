﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Snake
{
	class SnekButton : Button
	{
		public SnekButton() : base()
		{
			FlatStyle = FlatStyle.Flat;
			BackColor = Color.DarkGray;
		}
	}
}
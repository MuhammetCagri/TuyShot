﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuyShot.Options.PictureBoxOptions
{
    public class PictureBoxOption :IOptions
    {
        public Point Coordinat { get; set; }
        public Point StartCoordinat { get; set; }
        public Size Size { get; set; }
        public bool IsSelectedScreenActive { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyGame.Properties;
using System.Resources;

namespace MyGame
{
    public partial class ucItem : UserControl
    {
        private int oldValue;
        public int OldVal
        {
            get
            {
                return oldValue;
            }
        }
        public int OldValue
        {
            get
            {
                if (oldValue == 3) return 3;
                return 2;
            }
            set
            {
                oldValue = value;
            }
        }
        public ucItem()
        {
            InitializeComponent();
        }

        public void RefImage()
        {
            object obj = Resources.ResourceManager.GetObject("img" + this.Tag.ToString() );
            this.BackgroundImage= ((System.Drawing.Bitmap)(obj));
        }

        private void ucItem_Load(object sender, EventArgs e)
        {
            
            RefImage();
        }
    }
}

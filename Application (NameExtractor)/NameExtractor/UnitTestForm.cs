using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace NameExtractor
{
    public partial class UnitTestForm : Form
    {
        public UnitTestForm()
        {
           //registering tested and testing classes
            Type[] typearr = { typeof(NameExtractor), typeof(UnitTestDriver) };
            TestComplete.UnitTesting.AddClasses(typearr);
            InitializeComponent();
            UnitTestDriver utd = new UnitTestDriver();
            
        }
    }
}
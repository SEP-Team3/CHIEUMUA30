using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Educational_Program
{
    public partial class GUI_VIEW : Form
    {
        TableLayoutPanel ndctpn;
        FlowLayoutPanel khgdpn;
        TableLayoutPanel dspn;
        TableLayoutPanel ndvt;
        public GUI_VIEW(TableLayoutPanel indct,FlowLayoutPanel ikhgd,TableLayoutPanel ids,TableLayoutPanel indvt)
        {
            InitializeComponent();
            ndctpn = indct;
            khgdpn = ikhgd;
            dspn = ids;
            ndvt = indvt;
            loadform();
        }
        private void loadform()
        {
            ndctpn.AutoScroll = true;
            ndctpn.Dock = DockStyle.Fill;
            ndctpn.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            this.tbMain.TabPages[0].Controls.Add(ndctpn);

            khgdpn.AutoScroll = true;
            Panel pn = new Panel();
            pn.Dock = DockStyle.Fill;
            pn.Controls.Add(khgdpn);
            pn.AutoScroll = true;
            this.tbMain.TabPages[1].Controls.Add(pn);

            ndvt.AutoScroll = true;
            ndvt.Dock = DockStyle.Fill;
            ndvt.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            this.tbMain.TabPages[2].Controls.Add(ndvt);

            dspn.AutoScroll = true;
            dspn.Dock = DockStyle.Fill;
            this.tbMain.TabPages[3].Controls.Add(dspn);

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.Lib
{
    class Makeup
    {
        public static void DataGridView(DataGridView dataGridView)
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(238, 75, 43);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 209, 155);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman     ", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView.BackgroundColor = Color.White;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 30;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.DefaultCellStyle.Font = new Font("Times New Roman", 12);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView.AllowUserToResizeRows = false;
        }
    }
}

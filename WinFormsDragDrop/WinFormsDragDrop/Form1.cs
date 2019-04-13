using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDragDrop
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

       
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.AllowDrop = true;
            listView2.AllowDrop = true;
            listView1.Items.Add(new ListViewItem() { Text="List 1 Item 1" });
            listView1.Items.Add(new ListViewItem() { Text = "List 1 Item 2" });
            listView2.Items.Add(new ListViewItem() { Text = "List 2 Item 1" });
            listView2.Items.Add(new ListViewItem() { Text = "List 2 Item 2" });

        }




        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var items = new List<ListViewItem>();
            items.Add((ListViewItem)e.Item);
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                if (!items.Contains(lvi))
                {
                    items.Add(lvi);
                }
            }
            listView1.DoDragDrop(items, DragDropEffects.Move);
        }

        private void listView2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));
                foreach (ListViewItem lvi in items)
                {
                    listView1.Items.Remove(lvi);
                    listView2.Items.Add(lvi);
                }
            }
        }

    }
}

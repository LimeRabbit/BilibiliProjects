using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class ListviewVitual : Form
    {
        public ListviewVitual()
        {
            InitializeComponent();
            comboBox_count.SelectedIndex = 0;
        }

        /// <summary>
        /// 向listview和datagridview添加数据
        /// </summary>
        /// <param name="itemsAll">要填充的项</param>
        private void AddAllItem(List<ListViewItem> itemsAll)
        {
            //先清除项
            listView1.Items.Clear();
            dataGridView1.Rows.Clear();
            if (lviList != null)
            {
                //设置项的数量
                listView1.VirtualListSize = lviList.Count;
                //填充项
                listView1.RetrieveVirtualItem +=
                    new RetrieveVirtualItemEventHandler(listView_RetrieveVirtualItem);
            }

            if (dataList != null)
            {
                //设置项的数量
                dataGridView1.RowCount = dataList.Count;
                //填充项
                dataGridView1.CellValueNeeded += DataGridView1_CellValueNeeded;
            }
        }

        //DataGridView填充数据
        private void DataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if(e.ColumnIndex==0)  //第一列，显示数字，方便查看行数
                e.Value = e.RowIndex;
            else  //其他列显示数组内容
                e.Value = dataList[e.RowIndex][e.ColumnIndex];
        }

        //ListView填充数据
        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //虚拟模式下的填充项方式
            e.Item = this.lviList[e.ItemIndex];
        }
        //双击listview项
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string s = richTextBox_list.Text.Trim();
            //双击时选中的项
            ListViewItem item = listView1.Items[listView1.SelectedIndices[0]];
            for (int i = 0; i < item.SubItems.Count; i++)
            {
                s += "\n" + item.SubItems[i].Text;//把一行中的所有子项拼接起来
            }
            richTextBox_list.Text = s.Trim();  //显示出来
        }
        //双击datagridview项
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string s = richTextBox_datagrid.Text.Trim();
            DataGridViewRow row = dataGridView1.SelectedRows[0]; //双击时选中的项
            for (int i = 0; i < row.Cells.Count; i++)
            {
                s += "\n" + row.Cells[i].Value;  //把一行中的所有单元格拼接起来
            }
            richTextBox_datagrid.Text = s.Trim();  //显示出来
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            int count = 50000;
            int.TryParse(comboBox_count.SelectedItem.ToString(), out count);
            SetData(count);
        }


        
        List<ListViewItem> lviList; //listview中的数据
        List<string[]> dataList;    //datagridview中的数据
        /// <summary>
        /// 生成要显示的数据
        /// </summary>
        /// <param name="count">要填充的行数</param>
        private void SetData(int count)
        {
            lviList = new List<ListViewItem>();
            dataList = new List<string[]>();
            string[] s = new string[10];
            //生成10列数据，即一行数据
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = "测试" + i;
            }

            string info = ""; //一会弹窗显示的文本
            info+="点击按钮  "+DateTime.Now.ToString("HH:mm:ss.fff");
            for (int i = 0; i < count; i++)
            {
                s[0] = i.ToString();
                lviList.Add(new ListViewItem(s));
                dataList.Add(s);
            }
            info += "\n生成数据后，填充列表前  " + DateTime.Now.ToString("HH:mm:ss.fff");
            AddAllItem(lviList);
            info += "\n填充列表后  " + DateTime.Now.ToString("HH:mm:ss.fff");
            MessageBox.Show(info);
        }
    }
}

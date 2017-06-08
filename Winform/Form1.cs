using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //進行存取的機碼路徑
        string sDir = "HKEY_CURRENT_USER\\SOFTWARE\\SONY\\JVC";

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //**********************************************
            //寫入機碼的方法================================
            //**********************************************
            // 寫入單一值
            Registry.SetValue(sDir, "Developer", "MEGA", RegistryValueKind.String);
            MessageBox.Show("寫入完畢"); 
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            //**********************************************
            //寫入機碼的方法================================
            //**********************************************
            // 寫入字串陣列值
            string[] ss = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            Registry.SetValue(sDir, "TestArray", ss, RegistryValueKind.MultiString); 
            MessageBox.Show("寫入完畢");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //**********************************************
            //寫入機碼的方法================================
            //**********************************************
            // 寫入整數資料
            Registry.SetValue(sDir, "TestInt", 10, RegistryValueKind.DWord); 
            MessageBox.Show("寫入機碼10");
        }

        private void button4_Click(object sender, EventArgs e)
        {     
            //**********************************************
            //讀取機碼的方法================================
            //**********************************************
            //這裡直接使用.CurrentUser因此後面抓取只需選擇後面路徑
            RegistryKey Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SONY\\JVC");
            string GetValue = Key.GetValue("TestInt").ToString();
            MessageBox.Show("讀取機碼為"+ GetValue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //**********************************************
            //修改機碼的方法================================
            //**********************************************
            //抓取JVC資料進行加1的動作在寫回
            int intReg = Convert.ToInt32(Registry.CurrentUser.OpenSubKey("SOFTWARE\\SONY\\JVC").GetValue("TestInt"));
            intReg += 1;
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\SONY\\JVC", true).SetValue("TestInt", intReg);
            MessageBox.Show("修改機碼為" + intReg.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //**********************************************
            //刪除機碼的方法================================
            //**********************************************
            //先檢查下層目錄資料是否存在，如果存在刪除
            //刪除HKEY_CURRENT_USER\SOFTWARE\SONY底下所有目錄
            string sDir = "SOFTWARE\\SONY";
            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\SONY\\JVC", true) != null)
            {
                Registry.CurrentUser.DeleteSubKeyTree(sDir);
                MessageBox.Show("刪除機碼完畢");
            }
        }

    }
}

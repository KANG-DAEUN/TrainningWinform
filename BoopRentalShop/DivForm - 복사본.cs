using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace BoopRentalShop
{
    public partial class DivForm : MetroForm
    {

        string strConString = "Data Source=192.168.0.18;Initial Catalog=BookRentalshopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public DivForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateData(); // 데이터 그리드 DB 데이터 로딩하기
        }

        private void UpdateData()
        {
            //throw new NotImplementedException();
            using (SqlConnection conn = new SqlConnection(strConString))
            {
                conn.Open(); // DB 열기
                string strQuery = "SELECT Division, Names FROM dbo.divtbl";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn); // 데이터를 가져오는 플러그
                DataSet ds = new DataSet(); //데이터를 담는 집합
                dataAdapter.Fill(ds, "divtbl"); // divtbl로 채워넣기

                GrdDivTbl.DataSource = ds; //붓기
                GrdDivTbl.DataMember = "divtbl"; //
            }
        }

        private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtDivision.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;
                TxtDivision.BackColor = Color.Beige;

                mode = "UPDATE";

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CleartextControls();

            mode = "INSERT";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveProcess();
            UpdateData();

            CleartextControls();
        }

        private void CleartextControls()
        {
            TxtDivision.Text = TxtNames.Text = "";
            TxtDivision.ReadOnly = false;
            TxtDivision.BackColor = Color.White;
            TxtDivision.Focus();
        }

        private void SaveProcess()
        {
            if (string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            using (SqlConnection conn = new SqlConnection(strConString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";
                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.divtbl " +
                    "   SET Names = @Names " +
                     " WHERE Division = @Division ";
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.divtbl (Division ,Names) " 
                        +" VALUES (@Division, @Names) ";
                }

                cmd.CommandText = strQuery;

                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);

                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = TxtDivision.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();
            }
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                BtnSave_Click(sender, new EventArgs());
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈값은 삭제할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DeleteProcess();
            UpdateData();
            CleartextControls();
        }

        private void DeleteProcess()
        {

            using (SqlConnection conn = new SqlConnection(strConString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM dbo.divtbl "
                                    + " WHERE Division = @Division ";
                SqlParameter paraDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                paraDivision.Value = TxtDivision.Text;
                cmd.Parameters.Add(paraDivision);

                cmd.ExecuteNonQuery();
            }
        }
    }
}


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
    public partial class UserForm : MetroForm
    {

        string strConString = "Data Source=192.168.0.18;Initial Catalog=BookRentalshopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public UserForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateData(); // 데이터 그리드 DB 데이터 로딩하기
        }
        /// <summary>
        /// 사용자 데이터 가져오기
        /// </summary>
        private void UpdateData()
        {
            //throw new NotImplementedException();
            using (SqlConnection conn = new SqlConnection(strConString))
            {
                conn.Open(); // DB 열기
                string strQuery = "SELECT id,userID,password,lastLoginDt,loginIpAddr "
                     + " FROM dbo.userTbl";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn); // 데이터를 가져오는 플러그
                DataSet ds = new DataSet(); //데이터를 담는 집합
                dataAdapter.Fill(ds, "userTbl"); // userTbl 채워넣기

                GrdUserTbl.DataSource = ds; //붓기
                GrdUserTbl.DataMember = "userTbl"; 

            }
            DataGridViewColumn column = GrdUserTbl.Columns[0]; //id컬럼
            column.Width = 40;
            column.HeaderText = "순번";
            column = GrdUserTbl.Columns[1]; // userID 컬럼
            column.Width = 80;
            column.HeaderText = "아이디";
            column = GrdUserTbl.Columns[2]; // password 컬럼
            column.Width = 100;
            column.HeaderText = "패스워드";
            column = GrdUserTbl.Columns[3]; //최종접속시간
            column.Width = 120;
            column.HeaderText = "최종접속시간";
            column = GrdUserTbl.Columns[4]; // 접속아이피주소
            column.Width = 150;
            column.HeaderText = "접속아이피주소";


        }
        /// <summary>
        /// 그리드 셀 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdUserTbl.Rows[e.RowIndex];
                TxtId.Text = data.Cells[0].Value.ToString();
                TxtUserid.Text = data.Cells[1].Value.ToString();
                TxtPassword.Text = data.Cells[2].Value.ToString();

                TxtUserid.ReadOnly = true;
                TxtUserid.BackColor = Color.Beige;

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
            if (string.IsNullOrEmpty(TxtUserid.Text) || string.IsNullOrEmpty(TxtPassword.Text))
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
            TxtId.Text = TxtUserid.Text = TxtPassword.Text = "";

            TxtUserid.Focus();
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
                    strQuery = "UPDATE dbo.userTbl " +
                                  " SET userID = @UserID " +
                                      " , password = @password " +
                                "  WHERE Id = @Id ";
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.userTbl " +
                                 "  (userID, password) " +
                                 " VALUES (@UserID, @Password) ";
                }

                cmd.CommandText = strQuery;

                SqlParameter parmUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 12);
                parmUserID.Value = TxtUserid.Text;
                cmd.Parameters.Add(parmUserID);

                SqlParameter parmPassword = new SqlParameter("@password", SqlDbType.VarChar, 20);
                parmPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmPassword);

                if (mode == "UPDATE")
                {
                    SqlParameter parmId = new SqlParameter("@Id", SqlDbType.Int);
                    parmId.Value = TxtId.Text;
                    cmd.Parameters.Add(parmId);
                }

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
            if (string.IsNullOrEmpty(TxtUserid.Text) || string.IsNullOrEmpty(TxtPassword.Text))
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
                paraDivision.Value = TxtUserid.Text;
                cmd.Parameters.Add(paraDivision);

                cmd.ExecuteNonQuery();
            }
        }

        private void TxtUserid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
namespace BoopRentalShop
{
    public partial class LoginForm : MetroForm
    {
        string strConString = "Data Source=192.168.0.18;Initial Catalog=BookRentalshopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        // 캔슬 버튼 이벤트 부터 만들기가 이득
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0); // 두가지 방법
        }
        //로그인 처리버튼 이벤트 
        private void BtnOK_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }
        private void TxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13) // 대문자 Char : .NET 전체 (클래스) , 소문자 char : C# 데이터 타입형
            { //엔터
                TxtPassword.Focus(); // 엔터치면 밑으로
            }
        }
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == (Char)13)
                {
                    LoginProcess();// alt+enter -> 메소드 생성 : 메소드가 자동으로 생성
                }
        }
        private void LoginProcess()
        {
            //throw new NotImplementedException();
            if((string.IsNullOrEmpty(TxtUserID.Text)) ||
                (string.IsNullOrEmpty(TxtPassword.Text)))
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string strUserId = string.Empty;

            using (SqlConnection conn = new SqlConnection(strConString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT userID FROM userTbl "+
                                  " WHERE userID = @userID " +
                                  " AND password = @password";
                SqlParameter parmUserId = new SqlParameter("@userID", SqlDbType.VarChar, 12);
                parmUserId.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserId);

                SqlParameter parmpassword = new SqlParameter("@password", SqlDbType.VarChar, 20);
                parmpassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmpassword);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                strUserId = reader["userID"].ToString();
                MetroMessageBox.Show(this, "접속성공", "로그인");
                Debug.WriteLine("On the Debug");



            }
        }
    }
}

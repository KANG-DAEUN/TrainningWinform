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
            if (string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))         //null이거나 값이 비어있을 때
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                      //ID,Password창이 비어있을 때 오류가 뜬다고 알려줘야함
                return;

            }
            //로그인 창, 비밀번호 창의 값이 비어있으면 안된다.

            string strUserid = string.Empty;

            try                                                                                 // try ~ catch구문 (Error 핸들링)
            {
                using (SqlConnection conn = new SqlConnection(strConString))               //Sql 연결하는 것
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select userID from usertbl " +
                        " where userid = @userID " +
                        " and password = @Password";
                    SqlParameter parmUserID = new SqlParameter("@userID", SqlDbType.VarChar, 12);               //DB의 type과 int size를 넣어야함
                    parmUserID.Value = TxtUserID.Text;
                    cmd.Parameters.Add(parmUserID);
                    //ID
                    SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                    parmPassword.Value = TxtPassword.Text;
                    cmd.Parameters.Add(parmPassword);
                    //Password

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    strUserid = reader["userID"] != null ? reader["userID"].ToString() : "";               //아이디값이 없을 때


                    if (strUserid != "")
                    {
                        MetroMessageBox.Show(this, "접속성공", "로그인성공");
                        this.Close();                                           //Loginform창이 닫힘
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "접속실패", "로그인실패",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                    //Debug.WriteLine("On the Debug");


                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error : {ex.StackTrace}", "오류",            // StackTrace : 오류난 곳의 코드 주소를 보여줌 (개발자가 봄)
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;


            }

        }
    }
}
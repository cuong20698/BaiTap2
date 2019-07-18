using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DangKyThanhVien
{
    public partial class DangKyThanhVIen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnDangKy_Click1(object sender, EventArgs e)
        {
            string firstName = txtFName.Text;
            string lastName = txtLName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            bool gender = Boolean.Parse(ddlGender.SelectedValue);
            string username = txtUser.Text;
            string password = txtPass.Text;
      

            UserDAO DAO = new UserDAO();

            bool exits = DAO.CheckUser(username);
            if (exits)
            {
                lblThognBao.Text = "Username này đã tồn tại vui lòng chọn một usernaem khác";
            }
            else
            {
                User user = new User
                {
                    UserName = username,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PassWord = password,
                    Gender = gender,
                    Address = address
                };

                if (password != txtConfPass.Text)
                {
                    lblThognBao.Text = "Mật khẩu không khớp vui lòng nhập lại!";
                }
                else
                {
                    bool result = DAO.Insert(user);
                    if (result)
                    {
                        lblThognBao.Text = "Đăng ký thành công!";
                    }
                    else
                    {
                        lblThognBao.Text = "Có lỗi. Vui lòng thử lại!";
                    }
                }
            }
        }
    }
}
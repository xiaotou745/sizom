using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Art.Web.Models
{
    public class NRegisterModel
    {
        [Required(ErrorMessage = "登录名不能为空")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "登录邮箱：")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "昵称不能为空")]
        [DataType(DataType.Text)]
        [Display(Name = "昵称：")]
        public string TrueName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, ErrorMessage = "6-16个字符，请使用数字与字母结合", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码：")]
        public string Password1 { get; set; }

        [Required(ErrorMessage = "请再次输入密码")]
        [DataType(DataType.Password)]
        [Display(Name = "确认密码：")]
        [Compare("Password1", ErrorMessage = "两次密码输入不一致!")]
        public string ConfirmPassword { get; set; }
    }
}
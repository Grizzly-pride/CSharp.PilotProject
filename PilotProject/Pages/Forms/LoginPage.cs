﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.Services;
using static System.Console;

namespace PilotProject.Pages.Forms
{
    internal class LoginPage : BasePage
    {
        private string _name;
        private string _password;
        public override string TitlePage => "LOGIN";
        public LoginPage(PageController controller) : base(controller)
        {
            CreateWindow();
        }
        public override void Enter()
        {
            CursorVisible = true;
            UpdateForm();
        }
        public override void UpdateForm()
        {           
            base.UpdateForm();

            for (int i = 0; i < itemsForm.Length; i++)
            {
                Write($" {itemsForm[i]}: ");

                switch (i)
                {
                    case 0: _name = ReadLine(); break;
                    case 1: _password = ReadLine(); break;
                }
            }
            WriteLine();

            if (Authentication())
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Successful login");             
                ReadKey();
                controller.TransitionToPage(Page.Main);
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid password or username!");
                ReadKey();
                controller.TransitionToPage(Page.Cross);
            }
        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            itemsForm = new string[]
            {
                " Name",
                " Password"
            };
        }

        private bool Authentication()
        {
            ApplicationContext db = new();
            List<User> users = db.Users.ToList();

            foreach (var user in users)
            {
                if (user.Name.Equals(_name) && user.Password.Equals(_password))
                {
                    OrderBasketRepository.UserName = user.Name;
                    return true;
                }
            }         
            return false;
        }

        public override void Exit()
        {
            controller.PreviousPage = Page.LoginPage;
            base.Exit();
        }
    }
}

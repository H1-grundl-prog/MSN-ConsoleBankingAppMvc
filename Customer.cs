﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankingAppMvc
{
    public class Customer
    {
        // Constructors
        public Customer()
        {
            accountNumbers = new List<string>();
        }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            UUID = Guid.NewGuid().ToString();

            accountNumbers = new List<string>();
        }

        // Properties
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string UUID { get; set; }
        public List<string> accountNumbers { get; set; }
    }
}

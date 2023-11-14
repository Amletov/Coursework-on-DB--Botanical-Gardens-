using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.ViewModels.Tables
{
    public class ServiceViewModel
    {
        private int id;
        private string careProduct;
        private int amount;
        private string fertilized;
        private string employee;
        private string plant;

        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public string CareProduct { get => careProduct; set => careProduct = value; }
        public string Fertilized { get => fertilized; set => fertilized = value; }
        public string Employee { get => employee; set => employee = value; }
        public string Plant { get => plant; set => plant = value; }
    }
}

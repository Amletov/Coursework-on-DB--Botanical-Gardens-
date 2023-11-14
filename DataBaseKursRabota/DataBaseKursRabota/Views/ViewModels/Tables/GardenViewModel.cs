using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.ViewModels.Tables
{
    public class GardenViewModel
    {
        private int id;
        private string garden;
        private int opening;
        private Int64 phone;
        private bool financing;
        private string city;
        private string property;
        private string employee;

        public int Id { get => id; set => id = value; }
        public string Garden { get => garden; set => garden = value; }
        public int Opening { get => opening; set => opening = value; }
        public Int64 Phone { get => phone; set => phone = value; }
        public bool Financing { get => financing; set => financing = value; }
        public string City { get => city; set => city = value; }
        public string Property { get => property; set => property = value; }
        public string Employee { get => employee; set => employee = value; }
    }
}

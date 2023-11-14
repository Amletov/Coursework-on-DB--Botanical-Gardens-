using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public class GardenDataModel
    {
        private int id;
        private string garden;
        private int opening;
        private Int64 phone;
        private bool financing;
        private string city;
        private int cityId;
        private string property;
        private int propertyId;
        private string employee;
        private int employeeId;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("garden")] public string Garden { get => garden; set => garden = value; }
        [JsonProperty("opening")] public int Opening { get => opening; set => opening = value; }
        [JsonProperty("phone")] public Int64 Phone { get => phone; set => phone = value; }
        [JsonProperty("financing")] public bool Financing { get => financing; set => financing = value; }
        [JsonProperty("city")] public string City { get => city; set => city = value; }
        [JsonProperty("city_id")] public int CityId { get => cityId; set => cityId = value; }
        [JsonProperty("property")] public string Property { get => property; set => property = value; }
        [JsonProperty("property_id")] public int PropertyId { get => propertyId; set => propertyId = value; }
        [JsonProperty("employee")] public string Employee { get => employee; set => employee = value; }
        [JsonProperty("employee_id")] public int EmployeeId { get => employeeId; set => employeeId = value; }

        public override string ToString()
        {
            return Garden;
        }
    }
}

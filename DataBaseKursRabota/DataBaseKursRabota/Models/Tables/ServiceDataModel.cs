using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public class ServiceDataModel
    {
        private int id;
        private string careProduct;
        private int careProductId;
        private int amount;
        private string fertilized;
        private string employee;
        private int employeeId;
        private string plant;
        private int plantId;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("care_product")] public string CareProduct { get => careProduct; set => careProduct = value; }
        [JsonProperty("care_product_id")] public int CareProductId { get => careProductId; set => careProductId = value; }
        [JsonProperty("amount")] public int Amount { get => amount; set => amount = value; }
        [JsonProperty("fertilized")] public string Fertilized { get => fertilized; set => fertilized = value; }
        [JsonProperty("employee")] public string Employee { get => employee; set => employee = value; }
        [JsonProperty("employee_id")] public int EmployeeId { get => employeeId; set => employeeId = value; }
        [JsonProperty("plant")] public string Plant { get => plant; set => plant = value; }
        [JsonProperty("plant_id")] public int PlantId { get => plantId; set => plantId = value; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public class EmployeeDataModel
    {
        private int id;
        private string surname;
        private string name;
        private string patronymic;
        private string birth;
        private string position;
        private int positionId;
        private int experience;
        private int salary;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("surname")] public string Surname { get => surname; set => surname = value; }
        [JsonProperty("name")] public string Name { get => name; set => name = value; }
        [JsonProperty("patronymic")] public string Patronymic { get => patronymic; set => patronymic = value; }
        [JsonProperty("birth")] public string Birth { get => birth; set => birth = value; }
        [JsonProperty("position")] public string Position { get => position; set => position = value; }
        [JsonProperty("position_id")] public int PositionId { get => positionId; set => positionId = value; }
        [JsonProperty("experience")] public int Experience { get => experience; set => experience = value; }
        [JsonProperty("salary")] public int Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI_API_Synchronizer
{
    class ApiJson
    {
        public int id { get; set; }
        public int create_uid { get; set; }
        public DateTime create_date { get; set; }
        public int write_uid { get; set; }
        public DateTime date { get; set; }
        public string periode { get; set; }
        public decimal value { get; set; }
        public int department_id { get; set; }
        public string value2 { get; set; }
        public string value1 { get; set; }
        public string kpi { get; set; }
        public string type { get; set; }
        public object desc { get; set; }
    }
}

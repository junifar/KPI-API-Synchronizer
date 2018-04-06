using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace KPI_API_Synchronizer
{
    public partial class Synchronizer : Form
    {
        String dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", ConstantMysql.HOST, ConstantMysql.USERNAME, ConstantMysql.PASSWORD, ConstantMysql.DB_NAME);

        public Synchronizer()
        {
            InitializeComponent();
        }

        private void Synchronizer_Load(object sender, EventArgs e)
        {
            textBoxTahun.Text = DateTime.Now.Year.ToString();
            loadPeriodeKPI();
        }

        private void loadPeriodeKPI() {
            //var conn = new MySqlConnection(dbConnectionString);

            using (var conn = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    conn.Open();
                    var query = @"SELECT * FROM PERIOD ORDER BY ID DESC";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            comboBoxKPI.Items.Add(dataReader["start_year"] + "-" + dataReader["start_month"] + " S/D " + dataReader["end_year"] + "-" + dataReader["end_month"]);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Connection to Mysql Server Failed : " + e.Message, "Error", MessageBoxButtons.OK);
                    conn.Close();
                }
            }
        }

        private void logAdd(String message) {
            listBoxLog.Items.Add(DateTime.Now.ToString() + " : " + message);
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
            if (comboBoxBulan.Text == "")
            {
                MessageBox.Show("Bulan Tidak Valid");
                return;
            }

            if (textBoxTahun.Text == "") {
                MessageBox.Show("Tahun Tidak Valid");
                return;
            }

            this.logAdd("Beginning Sync Data To server");
            this.logAdd("Reading URL From KPI Database");
            buttonProcess.Enabled = false;

            Dictionary<string, int> month_list = new Dictionary<string, int>();
            month_list.Add("Januari", 1);
            month_list.Add("Februari", 2);
            month_list.Add("Maret", 3);
            month_list.Add("April", 4);
            month_list.Add("Mei", 5);
            month_list.Add("Juni", 6);
            month_list.Add("Juli", 7);
            month_list.Add("Agustus", 8);
            month_list.Add("September", 9);
            month_list.Add("Oktober", 10);
            month_list.Add("November", 11);
            month_list.Add("Desember", 12);

            month_list.TryGetValue(comboBoxBulan.Text, out int result);

            var arguments = new List<object>
            {
                result,
                textBoxTahun.Text,
                comboBoxKPI.Text.Split(' ')[0],
                comboBoxKPI.Text.Split(' ')[2],
            };

            backgroundWorkerProcess.RunWorkerAsync(arguments);
        }

        private Boolean check_mysql_connection(object sender)
        {            
            var conn = new MySqlConnection(dbConnectionString);
            try
            {
                conn.Open();
                (sender as BackgroundWorker).ReportProgress(0, "Connected to Mysql Server");
            }
            catch (MySqlException e)
            {
                (sender as BackgroundWorker).ReportProgress(0, "Connection to Mysql Server Failed : " + e.Message);
                conn.Close();
                conn.Dispose();
                return false;
            }
            conn.Close();
            conn.Dispose();
            return true;
        }

        private List<KpiItem> get_api_url_from_server(object sender, string start_periode, string end_periode) {

            var conn = new MySqlConnection(dbConnectionString);
            conn.Open();
            var query = @"SELECT
                            CONCAT(period.start_year, '-', period.start_month) AS start_periode,
                            CONCAT(period.end_year, '-', period.end_month) AS end_periode,
                            kpi_item.id,
                            kpi_item.external
                            FROM
                            kpi_item
                            INNER JOIN period ON kpi_item.period = period.id
                            WHERE
                            kpi_item.external <> '' AND
                            CONCAT(period.start_year, '-', period.start_month) = '{0}' AND
                            CONCAT(period.end_year, '-', period.end_month) = '{1}'";

            var cmd = new MySqlCommand(string.Format(query, start_periode, end_periode), conn);
            var dataReader = cmd.ExecuteReader();
            var kpiItemDatas = new List<KpiItem>();
            while (dataReader.Read())
            {
                var kpiItem = new KpiItem
                {
                    ID = (Int32)dataReader["id"],
                    External = dataReader["external"].ToString()
                };
                kpiItemDatas.Add(kpiItem);
                kpiItem = null;
            }

            conn.Close();
            cmd.Dispose();
            conn.Dispose();

            return kpiItemDatas;
        }

        private void backgroundWorkerProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonProcess.Enabled = true;
            GC.Collect();
        }

        private void backgroundWorkerProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            var arguments = e.Argument as List<object>;
            var bulan = (int)arguments[0];
            var tahun = (string)arguments[1];
            var start_periode = (string)arguments[2];
            var end_periode = (string)arguments[3];

            if (check_mysql_connection(sender) == false) {
                return;
            }

            var datas_url = get_api_url_from_server(sender, start_periode, end_periode);
            foreach (var data in datas_url)
            {
                (sender as BackgroundWorker).ReportProgress(0, "Process Parsing URL : " + data.External.Replace("{month}", bulan.ToString()).Replace("{year}", tahun));
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(data.External.Replace("{month}", bulan.ToString()).Replace("{year}", tahun));
                    (sender as BackgroundWorker).ReportProgress(0, json);

                    if (json == "[]")
                    {
                        continue;
                    }

                    //var test1 = serializer.Deserialize<List<ApiJson>>(json);

                    var test = json.Replace("[", "").Replace("]", "");
                    if (json.Contains("["))
                    {
                        var apiJson = JsonConvert.DeserializeObject<List<ApiJson>>(json);
                        (sender as BackgroundWorker).ReportProgress(0, "Response Data == " + apiJson[0].id);
                    }
                    else {
                        var apiJson = JsonConvert.DeserializeObject<ApiJson>(json);
                        (sender as BackgroundWorker).ReportProgress(0, "Response Data == " + apiJson.id);
                    }
                    //var apiJson = JsonConvert.DeserializeObject<List<ApiJson>>(json);
                    //ApiJson apiJson = JsonConvert.DeserializeObject<ApiJson>(json.Replace("[", "").Replace("]", ""));
                    //(sender as BackgroundWorker).ReportProgress(0, "Response Data == " + apiJson[0].id);
                }
            }
            

            (sender as BackgroundWorker).ReportProgress(0, "Still Running");
        }

        private void BackgroundWorkerProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.logAdd(e.UserState as string);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms
{
    using Newtonsoft.Json.Linq;

    public partial class ImportForm : Form
    {
        #region Constructors

        public ImportForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void ImportForm_Load(object sender, EventArgs e)
        {
            var client = new System.Net.Http.HttpClient();
            string teamsString = "https://statsapi.web.nhl.com/api/v1/teams/";
            var response = client.GetAsync(teamsString).Result;
            bool responseSuccessful = response.IsSuccessStatusCode;
            while ((!responseSuccessful) && (response.StatusCode != HttpStatusCode.NotFound))
            {
                response = client.GetAsync(teamsString).Result;
                responseSuccessful = response.IsSuccessStatusCode;
            }

            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);
            var teamsArray = json.SelectToken("teams");
            if (teamsArray != null)
                foreach (var x in teamsArray)
                {
                    string abrv = x.SelectToken("abbreviation").ToString();
                    this.label1.Text += $"{abrv}\n";
                }
        }

        #endregion Methods
    }
}
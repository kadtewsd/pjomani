using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using PJOMgmt.Resource;
using PJOMgmt.Resource.Impl;
using PJOMgmt.Util;
using PJOResourceMgmt.Mgmts.Impl;
using PJOResourceMgmt.Mgmts.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace PJOMgmt
{
    public partial class PJOForm : System.Windows.Forms.Form
    {
        public PJOForm()
        {
            InitializeComponent();
            this.txtAccount.Text = ConfigurationManager.AppSettings["accountName"] + "@" + ConfigurationManager.AppSettings["tenantName"] + ".onmicrosoft.com";
            this.txtPassword.Text = ConfigurationManager.AppSettings["password"];
            this.BuildDropDown();
            this.txtAug.Text = "80";
            this.txtStdRate.Text = "23";
            this.lblDataCnt.Text = this.TestData.Count.ToString();

            this.txtAdditional.Text = "0";
        }

        PJOController controller = new PJOController();
        private void BuildDropDown()
        {
            string url = ConfigurationManager.AppSettings["url"];
            foreach (string val in url.Split(','))
            {
                this.ddlUrl.Items.Add(val);
            }
            this.ddlUrl.SelectedIndex = 0;

        }

        public string Account
        {
            get
            {
                return this.txtAccount.Text;
            }
        }

        public string Password
        {
            get
            {
                return this.txtPassword.Text;
            }

        }

        public string Url
        {
            get
            {
                return this.ddlUrl.SelectedItem.ToString();
            }
        }

        public int MaxResource
        {
            get
            {
                return int.Parse(this.txtAug.Text);
            }
        }

        public int AdditionalCount
        {
            get
            {
                return int.Parse(this.txtAdditional.Text);
            }
        }

        public void SetAdditional(string val)
        {
            txtAdditional.Text = val;
        }

        public IList<ResourceDTO> TestData
        {
            get
            {
                return new PJOUtil(this).BuildResourceInfo();
            }
        }

        public int GetStandardRate()
        {
            int result = 14;
            int.TryParse(this.txtStdRate.Text, out result);
            return result;
        }

        private void btnCnt_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, EnterpriseResourceCollection> res = new EnterpriseResourcesRetriever(this);
            EventResult<EnterpriseResourceCollection> result = controller.DoMain(res);
        }

        private void btnRsrcDel_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, EnterpriseResourceCollection> del = new DeleteEnterpriseResource(this);
            EventResult<EnterpriseResourceCollection> result = controller.DoMain(del);
        }

        private void btnRsrcAdd_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, EnterpriseResourceCollection> creator = new CreateEnterpriseResource(this);
            EventResult<EnterpriseResourceCollection> result = controller.DoMain(creator);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, EnterpriseResource> retrieve = new ResourceRetriever(this);
            EventResult<EnterpriseResource> result = controller.DoMain(retrieve);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, EnterpriseResourceCollection> cost = new ResourceCost(this);
            EventResult<EnterpriseResourceCollection> result = controller.DoMain(cost);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, IList<string>> mpr = new ProjectForceCheckIn(this);
            EventResult<IList<string>> result = controller.DoMain(mpr);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            IPJOManipulator<PJOForm, ClientResult<Guid>> imp = new O365QueJob(this);
            EventResult<ClientResult<Guid>> result = controller.DoMain(imp);
        }
    }
}

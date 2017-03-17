using System;
using PJOMgmt.Util;
using Microsoft.Online.SharePoint.TenantManagement;
using System.Collections.Generic;
using Microsoft.SharePoint.Client;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace PJOMgmt.Resource.Impl
{
    public class O365QueJob : AbstractPJOMgmt<ClientResult<Guid>>
    {
        private class CustomPropertyValue
        {
            public string IdName { get; set; }
            public string BirthPlace { get; set; }
            public string GraduateDate { get; set; }
        }
        // from https://msdn.microsoft.com/en-us/library/office/microsoft.online.sharepoint.tenantmanagement.aspx
        public override EventResult<ClientResult<Guid>> Execute()
        {
            EventResult<ClientResult<Guid>> result = new EventResult<ClientResult<Guid>>();
            string filePath = CreatetImportValueFile();
            Office365Tenant tenant = new Office365Tenant(Param.Util.ProjContext);
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("BirthPlace", "brthPlace");
            dic.Add("GraduateDate", "grdDate");
            string sourceDataIdProperty = "IdName";
            string sourceUri = UploadJsonFile(Param, filePath);
            // 先行リリーステナントでないとつかえない？https://github.com/SharePoint/PnP/issues/1400

            Param.Util.ProjContext.Load(tenant);
            Param.Util.ProjContext.ExecuteQuery();
            result.Result = tenant.QueueImportProfileProperties(ImportProfilePropertiesUserIdType.Email, sourceDataIdProperty, dic, sourceUri);
            Param.Util.ProjContext.ExecuteQuery();
            if (result.Result.Value.Equals(Guid.Empty))
            {
                MessageBox.Show("先行リリースではないので使えないみたいです。");
            }
            System.IO.File.Delete(filePath);
            return result;
        }

        private string CreatetImportValueFile()
        {
            IList<CustomPropertyValue> valueList = new List<CustomPropertyValue>();

            Assembly assm = System.Reflection.Assembly.GetAssembly(this.GetType());
            using (StreamReader reader = new StreamReader(assm.GetManifestResourceStream("PJOResourceMgmt.CustomPropertyTargets.csv")))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {

                    CustomPropertyValue info = new CustomPropertyValue();
                    string[] lines = line.Split(',');
                    info.IdName = lines[0];
                    info.GraduateDate = DateTime.Now.AddYears(rnd.Next(birthPlance.Count - 1) * 5).ToString("yyyy/MM/dd hh:MM:ss");
                    info.BirthPlace = birthPlance[rnd.Next(birthPlance.Count - 1)];
                    valueList.Add(info);
                }
            }

            string json = JsonConvert.SerializeObject(valueList);

            string fileName = @".\importValue" + DateTime.Now.ToString("yyyyyMMddhhmmss") + ".json";
            // これでやるとプロセスが排他で開いている状態になっている。
            //System.IO.File.Create(fileName);
            //using (StreamWriter writer = new StreamWriter(fileName))
            //{
            //    writer.Write(json);
            //}
            System.IO.File.WriteAllText(fileName, json);
            return fileName;
        }


        Random rnd = new Random();
        static IList<string> birthPlance = new List<string>()
        {
            "東京都葛飾区亀有一丁目",
            "大阪府大阪市住吉区",
            "岐阜県岐阜市",
            "愛知県名古屋市昭和区",
            "大阪府守口市",
            "大阪府和泉市",
            "山口県下松市"
        };

        public override string ProcessName
        {
            get
            {
                return "ユーザープロファイルキューイング";
            }
        }

        public O365QueJob(PJOForm arg) : base(arg)
        {
        }

        private string UploadJsonFile(EventParameter param, string importValueFilePath)
        {
            const string listName = "Docs";

            List list = param.Util.ProjContext.Web.Lists.GetByTitle("Docs");
            param.Util.ProjContext.Load(list, i => i.RootFolder);
            try
            {
                param.Util.ProjContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                string createdUri = this.CreateDocs(listName);
                Console.WriteLine(("Created list uri is {0}"), createdUri);
            }
            FileCreationInformation path = new FileCreationInformation();
            path.Content = System.IO.File.ReadAllBytes(importValueFilePath);

            //string ext = "json";
            string ext = "txt";
            string fileName = "upload" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ext;
            var fileUrl = String.Format("{0}/{1}", list.RootFolder.ServerRelativeUrl,fileName);
            path.Url = fileUrl;
            Microsoft.SharePoint.Client.File file = list.RootFolder.Files.Add(path);
            param.Util.ProjContext.Load(file);
            param.Util.ProjContext.ExecuteQuery();

            return Param.Util.ProjContext.Url + "/" + listName + "/" + fileName;
        }

        private string CreateDocs(string name)
        {
            ListCreationInformation listInfo = new ListCreationInformation();
            listInfo.Description = "File Upload";
            listInfo.TemplateType = (int)Microsoft.SharePoint.Client.ListTemplateType.DocumentLibrary;
            listInfo.Title = name;
            Microsoft.SharePoint.Client.List docs = Param.Util.ProjContext.Web.Lists.Add(listInfo);
            Param.Util.ProjContext.Load(docs);
            Param.Util.ProjContext.ExecuteQuery();
            return  listInfo.Url;
        }
    }
}


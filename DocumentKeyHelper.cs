using DocumentKeyHelper.Utilities;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DocumentKeyHelper
{
    public partial class DocumentKeyHelper : Form
    {




        string sEsiDocumentKeys = string.Empty;
        string sDirectory = string.Empty;


        /* sEsiDocumentKeys Format
            "document_type": "850I",
            "file_format": "SPS_RSX_XML",
            "document_key": "081FDAE9-450B-479C-BC8F-DD589228C23B",
            "encrypted_key": "Q2ocZAcg7DCivFnyUhW8jTjYJHINbYE/rBBaOL078OrQ0sz744p2ggu150D+bOAFzsWgfhvmm9zXVAqeCAMpd+qhsuLPET3QezBo9CSeSvrj4oRHotkTGV9l0nOAtKJ/"
        */
        /*single key file will not contain 'document key'*/



        public DocumentKeyHelper()
        {
            InitializeComponent();
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {

            DataTable dtDocumentTypes = GetEdiDocuments();
            CreateDocumentKeys(dtDocumentTypes);
            string esiJsonData = CreateJson(dtDocumentTypes);
            string jsonData = CreateJson(dtDocumentTypes);
            BackupJsonFile(sEsiDocumentKeys);
            WriteJsonFile(sEsiDocumentKeys, jsonData);
            WriteDocumentKeyFile(dtDocumentTypes);

            MessageBox.Show("Done generating keys");



        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "json Files(.json)|*.json";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sEsiDocumentKeys = dlg.FileName;
                tbFileName.Text = sEsiDocumentKeys;
                sDirectory = System.IO.Path.GetDirectoryName(sEsiDocumentKeys);
            }





        }

        private DataTable GetEdiDocuments()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("document_type", typeof(string));
            //dt.Columns.Add("file_format", typeof(string));
            //dt.Columns.Add("document_key", typeof(string));
            //dt.Columns.Add("encrypted_key", typeof(string));

            string fileData = File.ReadAllText(sEsiDocumentKeys);

            try
            {
                dt = JsonConvert.DeserializeObject<DataTable>(fileData);

            }
            catch (Exception ex)
            {
            }

            return dt;
        }


        private void CreateDocumentKeys(DataTable dt)
        {

            string encryptedKey = string.Empty;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (string.IsNullOrEmpty(row["document_key"].ToString()))
                    {
                        row["document_key"] = Guid.NewGuid().ToString();
                    }
                    if (string.IsNullOrEmpty(row["encrypted_key"].ToString()))
                    {

                        //string s = row["document_type"].ToString()
                        //        + row["file_format"].ToString()
                        //        + row["document_key"].ToString();

                        //byte[] bytes = Encoding.ASCII.GetBytes(s);
                        row["encrypted_key"] = EncryptDecrypt.SimpleEncrypt(row["document_key"].ToString(), null);

                        string documentKey = row["document_key"].ToString();
                        string decryptedKey = EncryptDecrypt.SimpleDecrypt(row["encrypted_key"].ToString());


                    }
                    dt.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
            }




        }

        private string CreateEsiJson(DataTable dt)
        {
            string json = string.Empty;
            json = JsonConvert.SerializeObject(dt);

            return json;

        }
        private string CreateJson(DataTable dt)
        {

            string json = string.Empty;
            json = JsonConvert.SerializeObject(dt);

            return json;

        }



        private void WriteDocumentKeyFile(DataTable dt)
        {
            DataTable modifiedTable = dt;
            modifiedTable.Columns.Remove("document_key");
            foreach (DataRow dr in modifiedTable.Rows)
            {
                string sDocumentKeyFile = sDirectory + "\\" + "ESI_" + dr["document_type"].ToString() + "_" + dr["file_format"].ToString() + ".key";
                string json = string.Empty;

                DataTable keyTable = modifiedTable.Copy();
                keyTable.Rows.Clear();
                keyTable.Rows.Add(dr.ItemArray);

                json = JsonConvert.SerializeObject(keyTable);

                File.WriteAllText(sDocumentKeyFile, json);
            }
        }
        private void WriteJsonFile(string sKeyFileName, string jsonData)
        {
            File.WriteAllText(sKeyFileName, jsonData);
        }
        private void BackupJsonFile(string sKeyFileName)
        {
            string sBackupFileName = sKeyFileName + DateTime.Now.Ticks.ToString();
            File.Copy(sKeyFileName, sBackupFileName);
        }




    }



}

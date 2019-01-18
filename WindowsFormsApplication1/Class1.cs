using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Class1
    {
        /*
         * webservice has an ul configuration file
         */
        static string configFile = Application.StartupPath + @"\webServiceAvary.ini";

        /*
         * uplord function parameter should allow to modify with configuration file
         */
        //  static string username = "test1";
        //  static string password = "test1";
      //  static string equ_id = "ABC123456";

        public static string readCfgUrl()
        {
            if (true != System.IO.File.Exists(configFile))
            {
                return "NG: 設定檔[" + configFile + "]遺失!";
            }

            //read one line, get the webservice url
            System.IO.StreamReader sr = new System.IO.StreamReader(configFile, System.Text.Encoding.Default);
            string cfgStr = sr.ReadLine();
            sr.Dispose();
            sr.Close();

            return cfgStr;
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1());

            //string errorMessage = "";

            ///*
            // ********************************** webaccess測試 **********************************
            // */
            //WAWebService WaWebService = new WAWebService();
            //if (!WaWebService.Init("10.89.164.111", "HASMT", "admin", "123456"))
            //{
            //    throw new SystemException(WaWebService.GetErrMsg());
            //}

            //string[] tagName = new string[1];
            //string[] ret = new string[1];
            //tagName[0] = "A13SLBDO101";
            ////ret = WaWebService.GetValueText(tagName);

            //string setTagName = "VESTFULT";
            //WaWebService.SetValueText(setTagName, "10");
            ///*
            // ********************************** webaccess測試 **********************************
            // */


            //WebRefSample.Service1 webFun = new WebRefSample.Service1();
            //webFun.Url = readCfgUrl();
            //if (true == webFun.Url.StartsWith("NG:"))
            //{
            //    errorMessage = webFun.Url;
            //    //return error message
            //}
            //webFun.Discover();

            //string parameterName = "name1|name2|name3";
            //string parameterValue = "value1|value2|value3";
            //string ret = webFun.sendDataToSer(username, password, equ_id, parameterName, parameterValue,
            //                     System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            //if (ret == "OK")
            //{
            //    //send data correct
            //}
            //else
            //{
            //    //send data NG
            //    errorMessage = ret;
            //    //return error message
            //}
        }
    }
}

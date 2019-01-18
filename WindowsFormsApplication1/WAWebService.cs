using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
	public class WAWebService {
		private string m_Authorization;
		private string m_serverip;
		private string m_Proj;
		private string m_ErrMsg;

		public WAWebService() {
			m_Authorization = "";
			m_serverip = "";
			m_ErrMsg = "";
		}
		public string GetErrMsg() {
			return m_ErrMsg;
		}
		public bool Init(string serverip, string WaProjName, string user, string pwd) {
			m_serverip = serverip;
			m_Proj = WaProjName;
			m_Authorization = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + pwd));
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + serverip + "/WaWebService/Json/Login");
			request.Headers["Authorization"] = m_Authorization;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			return true;
		}
        ///// <summary>
        ///// Get values from WebAccess, not useable yet
        ///// </summary>
        ///// <param name="tagName"></param>
        ///// <returns></returns>
        //public string[] GetValueText(string[] tagName)
        //{
        //    m_ErrMsg = "";
        //    string[] result = new string[tagName.Length];
        //    TagValueParamObj tagValueParamObj = new TagValueParamObj();
        //    TagValueParam valParam;
        //    for (int i = 0; i < tagName.Length; i++)
        //    {
        //        valParam = new TagValueParam(tagName[i]);
        //        tagValueParamObj.Tags.Add(valParam);
        //    }
        //    string paramStr = JSONHelper.serialise(tagValueParamObj);
        //    byte[] reqBodyBytes = Encoding.UTF8.GetBytes(paramStr);

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
        //        "http://" + m_serverip + "/WaWebService/Json/GetTagValueText/" + m_Proj);
        //    request.ContentType = "application/json";
        //    request.Method = WebRequestMethods.Http.Post;
        //    request.Headers["Authorization"] = m_Authorization;

        //    System.IO.Stream reqStream = request.GetRequestStream();
        //    reqStream.Write(reqBodyBytes, 0, reqBodyBytes.Length);
        //    reqStream.Close();

        //    try
        //    {
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        System.IO.Stream resStream = response.GetResponseStream();
        //        byte[] buff = new byte[response.ContentLength];
        //        resStream.Read(buff, 0, (int)response.ContentLength);   //resStream.Length
        //        string resStr = Encoding.UTF8.GetString(buff);
        //    }
        //    catch (WebException ex)
        //    {
        //        m_ErrMsg = ex.Message;
        //        result[0] = m_ErrMsg;
        //    }
        //    return result;
        //}

		public bool SetValueText(string tagName, string tagValue) {
			m_ErrMsg = "";
			TagValueParamObj tagValueParamObj = new TagValueParamObj();
			tagValueParamObj.Tags.Add(new TagValueParam(tagName, tagValue));
			string paramStr = JSONHelper.serialise(tagValueParamObj);
			byte[] reqBodyBytes = Encoding.UTF8.GetBytes(paramStr);

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                "http://" + m_serverip + "/WaWebService/Json/SetTagValueText/" + m_Proj);
			request.ContentType = "application/json";
			request.Method = WebRequestMethods.Http.Post;
			request.Headers["Authorization"] = m_Authorization;

			System.IO.Stream reqStream = request.GetRequestStream();
			reqStream.Write(reqBodyBytes, 0, reqBodyBytes.Length);
			reqStream.Close();

			try {
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				System.IO.Stream resStream = response.GetResponseStream();
				byte[] buff = new byte[response.ContentLength];
				resStream.Read(buff, 0, (int)response.ContentLength);
				string resStr = Encoding.UTF8.GetString(buff);
				if (resStr != "{\"Ret\":0}") {
					m_ErrMsg = "Failed";
					return false;
				}
			} catch (WebException ex) {
				m_ErrMsg = ex.Message;
				return false;
			}
			return true;
		}

		public bool SetValuesNumeric(string tagName, string tagVal) {
			m_ErrMsg = "";
			TagValueParamObj tagValueParamObj = new TagValueParamObj();
			tagValueParamObj.Tags.Add(new TagValueParam(tagName, tagVal));
			string paramStr = JSONHelper.serialise(tagValueParamObj);
			byte[] reqBodyBytes = Encoding.UTF8.GetBytes(paramStr);

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + m_serverip + "/WaWebService/Json/SetTagValue/" + m_Proj);
			request.ContentType = "application/json";
			request.Method = WebRequestMethods.Http.Post;
			request.Headers["Authorization"] = m_Authorization;

			System.IO.Stream reqStream = request.GetRequestStream();
			reqStream.Write(reqBodyBytes, 0, reqBodyBytes.Length);
			reqStream.Close();

			try {
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				System.IO.Stream resStream = response.GetResponseStream();
				byte[] buff = new byte[response.ContentLength];
				resStream.Read(buff, 0, (int)response.ContentLength);
				string resStr = Encoding.UTF8.GetString(buff);
				if (resStr != "{\"Ret\":0}") {
					m_ErrMsg = "Failed";
					return false;
				}
			} catch (WebException ex) {
				m_ErrMsg = ex.Message;
				return false;
			}
			return true;
		}
	}

    public class JSONHelper
    {
        public JSONHelper() { }
        public static T Deserialise<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);  //for Newtonsoft 8.0.2
            //return JavaScriptConvert.DeserializeObject<T>(json);  //for Newtonsoft 2.0
        }
        public static string serialise(object obj)
        {
            //JsonSerializerSettings setting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(obj);

            //return JavaScriptConvert.SerializeObject(obj); //for Newtonsoft 2.0
        }
    }

	public class TagValueParamObj {
		public TagValueParamObj() { Tags = new List<TagValueParam>(); }

		//[DataMember(Name = "Tags")]
		public IList<TagValueParam> Tags { get; set; }
	}


	public class TagValueParam {
		public TagValueParam() { }
		public TagValueParam(string name) { this.Name = name; }
		public TagValueParam(string name, object value) {
			this.Name = name;
			this.Value = value;
		}

		//[DataMember(Name = "Name")]
		public string Name { get; set; }

		//[DataMember(Name = "Value")]
		public object Value { get; set; }

		public int Quality { get; set; }
	}

	//my defined
	public class WAGetValResult {
		public WAGetValResult() { }
		public int Ret { get; set; }
		public int Total { get; set; }
	}
	public class WAGetValValues {
		public WAGetValValues() { }
		public string Name { get; set; }
		public string Value { get; set; }
		public int Quality { get; set; }
	}

	public class WAGetValResponseObj {
		public WAGetValResponseObj() { }
		public WAGetValResult Result { get; set; }
		public WAGetValValues Values { get; set; }
	}
}
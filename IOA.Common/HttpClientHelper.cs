using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace IOA.Common
{
    /// <summary>
    /// 帮助类  API  
    /// </summary>
    public static class HttpClientHelper
    {
        private static string apiUri = System.Configuration.ConfigurationManager.AppSettings["apiUri"];
        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="httpType">请求类型：post、put、get、delete</param>
        /// <param name="actionName">方法名称</param>
        /// <param name="obj">对象参数</param>
        /// <returns></returns>
        public static string GetAll(HttpType httpType, string actionName, object obj = null)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri(apiUri);//写死了行不行？这里一定要写到我们的配置文件里
            if (apiUri.EndsWith("/") == false)//
            {
                apiUri += "/";
            }
            actionName = actionName.TrimStart('/');

            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //将接收到的实体对象序列化为json字符串
            var jsonString = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(jsonString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Task<HttpResponseMessage> task = null;
            switch (httpType)
            {
                case HttpType.HttpGet:
                    task = hc.GetAsync(actionName);
                    break;
                case HttpType.HttpPost:
                    task = hc.PostAsync(actionName, content);
                    break;
                case HttpType.HttpPut:
                    task = hc.PutAsync(actionName, content);
                    break;
                case HttpType.HttpDelete:
                    task = hc.DeleteAsync(actionName);
                    break;
            }
            task.Wait();
            var result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                var getresultstringTask = result.Content.ReadAsStringAsync();
                getresultstringTask.Wait();
                var json = getresultstringTask.Result;

                //进行一改造将后台返回的格式转化成：ResultData


                return json;
            }
            return null;
        }
    }

    /// <summary>
    /// Http请求类型:Post/Put/Get/Delete
    /// </summary>
    public enum HttpType
    {
        /// <summary>
        /// HttpGet 请求方式
        /// </summary>
        HttpGet,

        /// <summary>
        /// HttpDelete 请求方式
        /// </summary>
        HttpPost,

        /// <summary>
        /// HttpDelete 请求方式
        /// </summary>
        HttpPut,

        /// <summary>
        /// HttpDelete 请求方式
        /// </summary>
        HttpDelete
    }
}

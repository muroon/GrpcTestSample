using System;
using System.Collections;
using Proto.Data.Rest;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace GrpcTest.Model
{
    public class RestTestManager
    {
        public const string HostKey = "RestTestManager.Host";

        public const string PortKey = "RestTestManager.Port";

        public string Host;

        public int Port;

        public IEnumerator DoRestApiTest(int jobCount, Action callback = null)
        {
            for (int i = 0; i < jobCount; i++)
            {
                var url = string.Format("http://{0}:{1}?content=TestContent{2}", Host, Port, i);
                using (var req = UnityWebRequest.Get(url))
                {
                    yield return req.SendWebRequest();

                    if (req.isHttpError || req.isNetworkError)
                    {
                        throw new Exception(string.Format("DoRestApiTest. Error:{0}", req.error));
                    }

                    var bytes = req.downloadHandler.data;
                    var res = ResponseMessage.Parser.ParseFrom(bytes);
                }
            }

            if (callback != null)
                callback();
        }

        public IEnumerator DoRestApiJsonTest(int jobCount, Action callback = null)
        {
            var enc = Encoding.UTF8;
            for (int i = 0; i < jobCount; i++)
            {
                var url = string.Format("http://{0}:{1}/json?content=TestContent{2}", Host, Port, i);
                using (var req = UnityWebRequest.Get(url))
                {
                    yield return req.SendWebRequest();

                    if (req.isHttpError || req.isNetworkError)
                    {
                        throw new Exception(string.Format("DoRestApiJsonTest. Error:{0}", req.error));
                    }

                    var bytes = req.downloadHandler.data;
                    var res = JsonUtility.FromJson<ResponseJsonMessage>(enc.GetString(bytes));
                }
            }

            if (callback != null)
                callback();
        }
    }
}

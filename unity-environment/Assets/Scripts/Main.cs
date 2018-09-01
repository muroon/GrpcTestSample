using UnityEngine;
using System;
using GrpcTest.Model;

public class Main : MonoBehaviour {

    enum TestType
    {
        None,
        GrpcUnary,
        GrpcBiStream,
        RestfulApi,
        RestfulJsonApi,
    }

    int testCount = 1;

    int[] testCounts = new int[] { 1, 100, 500, 1000, 10000 };

    TestType type = TestType.None;

    System.Diagnostics.Stopwatch sw;

    string logContents = String.Empty;

    GrpcTestManager grpcTestManager = new GrpcTestManager();

    RestTestManager restTestManager = new RestTestManager();

    string grpcTestHost;

    string grpcTestPort;

    string restfulHost;

    string restfulPort;

    void Start()
    {
        grpcTestManager.Host = PlayerPrefs.GetString(GrpcTestManager.HostKey);
        grpcTestManager.Port = PlayerPrefs.GetInt(GrpcTestManager.PortKey);
        restTestManager.Host = PlayerPrefs.GetString(RestTestManager.HostKey);
        restTestManager.Port = PlayerPrefs.GetInt(RestTestManager.PortKey);

        grpcTestHost = grpcTestManager.Host;
        grpcTestPort = grpcTestManager.Port.ToString();
        restfulHost = restTestManager.Host;
        restfulPort = restTestManager.Port.ToString();
    }

    void DoTest()
    {
        sw = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            switch (type)
            {
                case TestType.GrpcUnary:
                    grpcTestManager.DoUnaryTest(testCount);
                    FinishTest();
                    break;
                case TestType.GrpcBiStream:
                    grpcTestManager.DoBiStreamTest(testCount);
                    FinishTest();
                    break;
                case TestType.RestfulApi:
                    StartCoroutine(restTestManager.DoRestApiTest(testCount, FinishTest));
                    break;
                case TestType.RestfulJsonApi:
                    StartCoroutine(restTestManager.DoRestApiJsonTest(testCount, FinishTest));
                    break;
            }

        }
        catch (Exception e)
        {
            sw.Stop();
            throw e;
        }
    }

    void FinishTest()
    {
        sw.Stop();

        var throughput = Math.Round(testCount / sw.Elapsed.TotalSeconds, 5);
        var result = string.Format("TestType:{0}, JobCount:{1} ElapseTime:{2:0.000}(second), Throughput:{3}(jobs/sec)\n", type, testCount, sw.Elapsed.TotalSeconds, throughput);

        #if UNITY_EDITOR
        Debug.Log(result);
        #endif

        logContents += result;
    }

    void StartTest(TestType targetType)
    {
        if (sw != null && sw.IsRunning)
            return;
        
        type = targetType;
        DoTest();
    }

    void OnGUI()
    {
        GUILayout.Space(20);

        // Server Info
        GUILayout.Label("Grpc Test:");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Host:", GUILayout.Width(40f));
        grpcTestHost = GUILayout.TextField(grpcTestHost);

        GUILayout.Space(10);

        GUILayout.Label("Port:", GUILayout.Width(40f));
        grpcTestPort = GUILayout.TextField(grpcTestPort);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.Label("Restful API Test:");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Host:", GUILayout.Width(40f));
        restfulHost = GUILayout.TextField(restfulHost);

        GUILayout.Space(10);

        GUILayout.Label("Port:", GUILayout.Width(40f));
        restfulPort = GUILayout.TextField(restfulPort);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Save Server Info", GUILayout.Width(200f)))
        {
            var port = 0;

            grpcTestManager.Host = grpcTestHost;
            PlayerPrefs.SetString(GrpcTestManager.HostKey, grpcTestHost);
            if (int.TryParse(grpcTestPort, out port)) {
                grpcTestManager.Port = port;
                PlayerPrefs.SetInt(GrpcTestManager.PortKey, port);
            }

            restTestManager.Host = restfulHost;
            PlayerPrefs.SetString(RestTestManager.HostKey, restfulHost);
            if (int.TryParse(restfulPort, out port)) {
                restTestManager.Port = port;
                PlayerPrefs.SetInt(RestTestManager.PortKey, port);
            }
        }

        GUILayout.Space(40);

        // Request Loop Count
        GUILayout.Label("Request Loop Count:");

        GUILayout.BeginHorizontal();
        foreach (var c in testCounts) {
            if (GUILayout.Button(c.ToString(), GUILayout.Height(100f), GUILayout.Width(100f)))
            {
                testCount = c;
                type = TestType.None;
            }
        }
        GUILayout.EndHorizontal();


        GUILayout.Space(40);

        // Request Type
        GUILayout.Label("Request Type:");

        if (GUILayout.Button("GrpcUnary", GUILayout.Height(100f))) {
            StartTest(TestType.GrpcUnary);
        }

        GUILayout.Space(20);

        if (GUILayout.Button("GrpcBiStream", GUILayout.Height(100f)))
        {
            StartTest(TestType.GrpcBiStream);
        }

        GUILayout.Space(20);

        if (GUILayout.Button("RestfulApi", GUILayout.Height(100f)))
        {
            StartTest(TestType.RestfulApi);
        }

        GUILayout.Space(20);

        if (GUILayout.Button("RestfulJsonApi", GUILayout.Height(100f)))
        {
            StartTest(TestType.RestfulJsonApi);
        }

        GUILayout.Space(40);

        // Result
        GUILayout.Label("Result:");

        if (GUILayout.Button("RestResult", GUILayout.Height(20f)))
        {
            logContents = String.Empty;
        }

        var style = GUI.skin.box;
        style.alignment = TextAnchor.UpperLeft;
        GUILayout.Label(logContents, style);
	}
}

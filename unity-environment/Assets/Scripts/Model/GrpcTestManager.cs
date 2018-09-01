using System;
using Grpc.Core;
using Proto.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcTest.Model
{
    public class GrpcTestManager
    {
        public const string HostKey = "GrpcTestManager.Host";

        public const string PortKey = "GrpcTestManager.Port";

        public string Host;

        public int Port;

        public void DoUnaryTest(int jobCount)
        {
            var channel = new Channel(Host, Port, ChannelCredentials.Insecure);
            var client = new DataManager.DataManagerClient(channel);

            for (int i = 0; i < jobCount; i++)
            {
                var res = client.UnaryTest(new RequestMessage { Content = "TestContent" + i });
            }

            channel.ShutdownAsync().Wait();
        }

        public void DoBiStreamTest(int jobCount)
        {
            var channel = new Channel(Host, Port, ChannelCredentials.Insecure);
            var client = new DataManager.DataManagerClient(channel);

            using (var call = client.BiStreamTest())
            {
                // Get ResponseMessage
                var responseTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        var res = call.ResponseStream.Current;
                    }
                });

                // Send RequestMessage
                Task.Run(async () => {
                    for (int i = 0; i < jobCount; i++)
                    {
                        var req = new RequestMessage { Content = "TestContent" + i };
                        await call.RequestStream.WriteAsync(req);
                    }
                }).Wait();
                call.RequestStream.CompleteAsync().Wait();

                responseTask.Wait();
            }

            channel.ShutdownAsync().Wait();
        }
    }
}

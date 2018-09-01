# GrpcTestSample

## Description

This is gRPC test samples which get the throughput.

### Comparison pattern

|type |data format  |server  |client  |client package  |
|:---|:---|:---|:---|:---|
|gRPC Unary RPC  |Protocol Buffers  |Go  |C#  |[Google.Protobuf](https://www.nuget.org/packages/google.protobuf/)  |
|gRPC Bidirectional streaming RPC  |Protocol Buffers  |Go  |C#  |[Google.Protobuf](https://www.nuget.org/packages/google.protobuf/)  |
|REST API (Protocol Buffers)  |Protocol Buffers  |Go  |C#  |[Google.Protobuf](https://www.nuget.org/packages/google.protobuf/)  |
|REST API (Json)  |Json  |Go  |C#  |[JsonUtility](https://docs.unity3d.com/ScriptReference/JsonUtility.html)  |

There are four RPC types of gRPC.
[Here](https://grpc.io/docs/guides/concepts.html) is easy to understand.

Among them, Unary RPC for sending and receiving streams here,
Bidirectional streaming RPC that uses HTTP / 2 streams and can transmit and receive multiple times,
And I chose the REST API (Protocol Buffers format format) as a comparison object.
The purpose of this is to compare pure gRPC and REST API which do not depend on format format.
Also added Json style REST API for clarity. (The detailed explanation of ※ REST API of Json format will be omitted)

### Result

![result](https://qiita-image-store.s3.amazonaws.com/0/76076/5e74f835-5d75-5161-5c1f-79292caab64e.png)

## Environment

- [Unity Client](unity-environment/)
- [Server Side(Go)](go-environment/)

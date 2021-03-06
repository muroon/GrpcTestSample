// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: data.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace Proto.Data {
  public static partial class DataManager
  {
    static readonly string __ServiceName = "proto.data.DataManager";

    static readonly grpc::Marshaller<global::Proto.Data.RequestMessage> __Marshaller_RequestMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Proto.Data.RequestMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Proto.Data.ResponseMessage> __Marshaller_ResponseMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Proto.Data.ResponseMessage.Parser.ParseFrom);

    static readonly grpc::Method<global::Proto.Data.RequestMessage, global::Proto.Data.ResponseMessage> __Method_UnaryTest = new grpc::Method<global::Proto.Data.RequestMessage, global::Proto.Data.ResponseMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UnaryTest",
        __Marshaller_RequestMessage,
        __Marshaller_ResponseMessage);

    static readonly grpc::Method<global::Proto.Data.RequestMessage, global::Proto.Data.ResponseMessage> __Method_BiStreamTest = new grpc::Method<global::Proto.Data.RequestMessage, global::Proto.Data.ResponseMessage>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "BiStreamTest",
        __Marshaller_RequestMessage,
        __Marshaller_ResponseMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Proto.Data.DataReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of DataManager</summary>
    public abstract partial class DataManagerBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Proto.Data.ResponseMessage> UnaryTest(global::Proto.Data.RequestMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///rpc ServerStreamTest (RequestMessage) returns (stream ResponseMessage) {}
      ///rpc ClientStreamTest (stream RequestMessage) returns (ResponseMessage) {}
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task BiStreamTest(grpc::IAsyncStreamReader<global::Proto.Data.RequestMessage> requestStream, grpc::IServerStreamWriter<global::Proto.Data.ResponseMessage> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for DataManager</summary>
    public partial class DataManagerClient : grpc::ClientBase<DataManagerClient>
    {
      /// <summary>Creates a new client for DataManager</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public DataManagerClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for DataManager that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public DataManagerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected DataManagerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected DataManagerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Proto.Data.ResponseMessage UnaryTest(global::Proto.Data.RequestMessage request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UnaryTest(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.Data.ResponseMessage UnaryTest(global::Proto.Data.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UnaryTest, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.Data.ResponseMessage> UnaryTestAsync(global::Proto.Data.RequestMessage request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UnaryTestAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.Data.ResponseMessage> UnaryTestAsync(global::Proto.Data.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UnaryTest, null, options, request);
      }
      /// <summary>
      ///rpc ServerStreamTest (RequestMessage) returns (stream ResponseMessage) {}
      ///rpc ClientStreamTest (stream RequestMessage) returns (ResponseMessage) {}
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::Proto.Data.RequestMessage, global::Proto.Data.ResponseMessage> BiStreamTest(grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return BiStreamTest(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///rpc ServerStreamTest (RequestMessage) returns (stream ResponseMessage) {}
      ///rpc ClientStreamTest (stream RequestMessage) returns (ResponseMessage) {}
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::Proto.Data.RequestMessage, global::Proto.Data.ResponseMessage> BiStreamTest(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_BiStreamTest, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override DataManagerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new DataManagerClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(DataManagerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_UnaryTest, serviceImpl.UnaryTest)
          .AddMethod(__Method_BiStreamTest, serviceImpl.BiStreamTest).Build();
    }

  }
}
#endregion

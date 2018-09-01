// Code generated by protoc-gen-go. DO NOT EDIT.
// source: protos/data.proto

/*
Package proto_data is a generated protocol buffer package.

It is generated from these files:
	protos/data.proto

It has these top-level messages:
	RequestMessage
	ResponseMessage
*/
package proto_data

import proto "github.com/golang/protobuf/proto"
import fmt "fmt"
import math "math"

import (
	context "golang.org/x/net/context"
	grpc "google.golang.org/grpc"
)

// Reference imports to suppress errors if they are not otherwise used.
var _ = proto.Marshal
var _ = fmt.Errorf
var _ = math.Inf

// This is a compile-time assertion to ensure that this generated file
// is compatible with the proto package it is being compiled against.
// A compilation error at this line likely means your copy of the
// proto package needs to be updated.
const _ = proto.ProtoPackageIsVersion2 // please upgrade the proto package

type RequestMessage struct {
	Content string `protobuf:"bytes,1,opt,name=content" json:"content,omitempty"`
}

func (m *RequestMessage) Reset()                    { *m = RequestMessage{} }
func (m *RequestMessage) String() string            { return proto.CompactTextString(m) }
func (*RequestMessage) ProtoMessage()               {}
func (*RequestMessage) Descriptor() ([]byte, []int) { return fileDescriptor0, []int{0} }

func (m *RequestMessage) GetContent() string {
	if m != nil {
		return m.Content
	}
	return ""
}

type ResponseMessage struct {
	Content string `protobuf:"bytes,1,opt,name=content" json:"content,omitempty"`
}

func (m *ResponseMessage) Reset()                    { *m = ResponseMessage{} }
func (m *ResponseMessage) String() string            { return proto.CompactTextString(m) }
func (*ResponseMessage) ProtoMessage()               {}
func (*ResponseMessage) Descriptor() ([]byte, []int) { return fileDescriptor0, []int{1} }

func (m *ResponseMessage) GetContent() string {
	if m != nil {
		return m.Content
	}
	return ""
}

func init() {
	proto.RegisterType((*RequestMessage)(nil), "proto.data.RequestMessage")
	proto.RegisterType((*ResponseMessage)(nil), "proto.data.ResponseMessage")
}

// Reference imports to suppress errors if they are not otherwise used.
var _ context.Context
var _ grpc.ClientConn

// This is a compile-time assertion to ensure that this generated file
// is compatible with the grpc package it is being compiled against.
const _ = grpc.SupportPackageIsVersion4

// Client API for DataManager service

type DataManagerClient interface {
	UnaryTest(ctx context.Context, in *RequestMessage, opts ...grpc.CallOption) (*ResponseMessage, error)
	// rpc ServerStreamTest (RequestMessage) returns (stream ResponseMessage) {}
	// rpc ClientStreamTest (stream RequestMessage) returns (ResponseMessage) {}
	BiStreamTest(ctx context.Context, opts ...grpc.CallOption) (DataManager_BiStreamTestClient, error)
}

type dataManagerClient struct {
	cc *grpc.ClientConn
}

func NewDataManagerClient(cc *grpc.ClientConn) DataManagerClient {
	return &dataManagerClient{cc}
}

func (c *dataManagerClient) UnaryTest(ctx context.Context, in *RequestMessage, opts ...grpc.CallOption) (*ResponseMessage, error) {
	out := new(ResponseMessage)
	err := grpc.Invoke(ctx, "/proto.data.DataManager/UnaryTest", in, out, c.cc, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *dataManagerClient) BiStreamTest(ctx context.Context, opts ...grpc.CallOption) (DataManager_BiStreamTestClient, error) {
	stream, err := grpc.NewClientStream(ctx, &_DataManager_serviceDesc.Streams[0], c.cc, "/proto.data.DataManager/BiStreamTest", opts...)
	if err != nil {
		return nil, err
	}
	x := &dataManagerBiStreamTestClient{stream}
	return x, nil
}

type DataManager_BiStreamTestClient interface {
	Send(*RequestMessage) error
	Recv() (*ResponseMessage, error)
	grpc.ClientStream
}

type dataManagerBiStreamTestClient struct {
	grpc.ClientStream
}

func (x *dataManagerBiStreamTestClient) Send(m *RequestMessage) error {
	return x.ClientStream.SendMsg(m)
}

func (x *dataManagerBiStreamTestClient) Recv() (*ResponseMessage, error) {
	m := new(ResponseMessage)
	if err := x.ClientStream.RecvMsg(m); err != nil {
		return nil, err
	}
	return m, nil
}

// Server API for DataManager service

type DataManagerServer interface {
	UnaryTest(context.Context, *RequestMessage) (*ResponseMessage, error)
	// rpc ServerStreamTest (RequestMessage) returns (stream ResponseMessage) {}
	// rpc ClientStreamTest (stream RequestMessage) returns (ResponseMessage) {}
	BiStreamTest(DataManager_BiStreamTestServer) error
}

func RegisterDataManagerServer(s *grpc.Server, srv DataManagerServer) {
	s.RegisterService(&_DataManager_serviceDesc, srv)
}

func _DataManager_UnaryTest_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(RequestMessage)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(DataManagerServer).UnaryTest(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: "/proto.data.DataManager/UnaryTest",
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(DataManagerServer).UnaryTest(ctx, req.(*RequestMessage))
	}
	return interceptor(ctx, in, info, handler)
}

func _DataManager_BiStreamTest_Handler(srv interface{}, stream grpc.ServerStream) error {
	return srv.(DataManagerServer).BiStreamTest(&dataManagerBiStreamTestServer{stream})
}

type DataManager_BiStreamTestServer interface {
	Send(*ResponseMessage) error
	Recv() (*RequestMessage, error)
	grpc.ServerStream
}

type dataManagerBiStreamTestServer struct {
	grpc.ServerStream
}

func (x *dataManagerBiStreamTestServer) Send(m *ResponseMessage) error {
	return x.ServerStream.SendMsg(m)
}

func (x *dataManagerBiStreamTestServer) Recv() (*RequestMessage, error) {
	m := new(RequestMessage)
	if err := x.ServerStream.RecvMsg(m); err != nil {
		return nil, err
	}
	return m, nil
}

var _DataManager_serviceDesc = grpc.ServiceDesc{
	ServiceName: "proto.data.DataManager",
	HandlerType: (*DataManagerServer)(nil),
	Methods: []grpc.MethodDesc{
		{
			MethodName: "UnaryTest",
			Handler:    _DataManager_UnaryTest_Handler,
		},
	},
	Streams: []grpc.StreamDesc{
		{
			StreamName:    "BiStreamTest",
			Handler:       _DataManager_BiStreamTest_Handler,
			ServerStreams: true,
			ClientStreams: true,
		},
	},
	Metadata: "protos/data.proto",
}

func init() { proto.RegisterFile("protos/data.proto", fileDescriptor0) }

var fileDescriptor0 = []byte{
	// 168 bytes of a gzipped FileDescriptorProto
	0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0xff, 0xe2, 0x12, 0x2c, 0x28, 0xca, 0x2f,
	0xc9, 0x2f, 0xd6, 0x4f, 0x49, 0x2c, 0x49, 0xd4, 0x03, 0xb3, 0x85, 0xb8, 0xc0, 0x94, 0x1e, 0x48,
	0x44, 0x49, 0x8b, 0x8b, 0x2f, 0x28, 0xb5, 0xb0, 0x34, 0xb5, 0xb8, 0xc4, 0x37, 0xb5, 0xb8, 0x38,
	0x31, 0x3d, 0x55, 0x48, 0x82, 0x8b, 0x3d, 0x39, 0x3f, 0xaf, 0x24, 0x35, 0xaf, 0x44, 0x82, 0x51,
	0x81, 0x51, 0x83, 0x33, 0x08, 0xc6, 0x55, 0xd2, 0xe6, 0xe2, 0x0f, 0x4a, 0x2d, 0x2e, 0xc8, 0xcf,
	0x2b, 0x4e, 0x25, 0xa8, 0xd8, 0x68, 0x09, 0x23, 0x17, 0xb7, 0x4b, 0x62, 0x49, 0xa2, 0x6f, 0x62,
	0x5e, 0x62, 0x7a, 0x6a, 0x91, 0x90, 0x1b, 0x17, 0x67, 0x68, 0x5e, 0x62, 0x51, 0x65, 0x48, 0x6a,
	0x71, 0x89, 0x90, 0x94, 0x1e, 0xc2, 0x09, 0x7a, 0xa8, 0xf6, 0x4b, 0x49, 0xa3, 0xca, 0xa1, 0xd8,
	0xa7, 0xc4, 0x20, 0xe4, 0xcb, 0xc5, 0xe3, 0x94, 0x19, 0x5c, 0x52, 0x94, 0x9a, 0x98, 0x4b, 0xa1,
	0x51, 0x1a, 0x8c, 0x06, 0x8c, 0x49, 0x6c, 0x60, 0x15, 0xc6, 0x80, 0x00, 0x00, 0x00, 0xff, 0xff,
	0x63, 0x99, 0x97, 0x8e, 0x27, 0x01, 0x00, 0x00,
}
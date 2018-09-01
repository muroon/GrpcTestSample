package main

import (
	"log"
	"net"
	"io"

	"golang.org/x/net/context"
	"google.golang.org/grpc"
	pb "grpc-test/protos"
	"google.golang.org/grpc/reflection"
)

const (
	port = ":50051"
)

type server struct{}


func (s *server) UnaryTest(ctx context.Context, in *pb.RequestMessage) (*pb.ResponseMessage, error) {
	return &pb.ResponseMessage{Content: in.Content}, nil
}

func (s *server) BiStreamTest(stream pb.DataManager_BiStreamTestServer) error {
	for {
		in, err := stream.Recv()
		if err == io.EOF {
			break
		}
		if err != nil {
			return err
		}
		stream.Send(&pb.ResponseMessage{Content: in.Content})
	}
	return nil // RPC終了
}

func main() {
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	s := grpc.NewServer()
	pb.RegisterDataManagerServer(s, &server{}) 

	// Register reflection service on gRPC server.
	reflection.Register(s)
	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}

package main

import (
	"fmt"
	"net/http"
	proto1 "grpc-test/protos-rest"
	"reflect"
	"strings"
	"encoding/json"

	"github.com/golang/protobuf/proto"
)

func RestProtoTest(w http.ResponseWriter, r *http.Request) {

	p := &proto1.ResponseMessage{Content:r.URL.Query().Get("content")}
	b, err := proto.Marshal(p)
	if err != nil {
		http.Error(w, err.Error(), 500)
		return
	}

	pt := fmt.Sprint(reflect.TypeOf(p))
        pt = strings.Replace(pt, "*", "", -1)

	w.Header().Set("Content-Type", "application/protobuf")
        w.Header().Set("Proto-Type", pt)
        w.WriteHeader(http.StatusOK)
        w.Write(b)
}

type ResponseJsonMessage struct {
        Content string `json:"content"`
}

func RestJsonTest(w http.ResponseWriter, r *http.Request) {

	p := &ResponseJsonMessage{Content:r.URL.Query().Get("content")}
	b, err := json.Marshal(p)
	if err != nil {
		http.Error(w, err.Error(), 500)
		return
	}

	w.Header().Set("Content-Type", "application/json;charset=utf-8")
        w.WriteHeader(http.StatusOK)
        w.Write(b)
}

func main() {
	http.HandleFunc("/", RestProtoTest)
	http.HandleFunc("/json", RestJsonTest)
	http.ListenAndServe(":8080", nil)
}


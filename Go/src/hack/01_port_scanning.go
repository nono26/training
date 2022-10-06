package main

import (
	"fmt"
	"log"
	"net"
	"strconv"
	"time"
)

var ipToScan = "192.168.0.1"
var minPort = 1
var maxPort = 65535

func main() {
	fmt.Println("Port scanning")

	activeThread := 0
	doneChannel := make(chan bool)

	for port := minPort; port <= maxPort; port++ {
		go testTCPConnection(ipToScan, port, doneChannel)
		activeThread++
	}

	for activeThread > 0 {
		<-doneChannel
		activeThread--
	}
}

func testTCPConnection(ip string, port int, doneChannel chan bool) {
	_, err := net.DialTimeout("tcp", ip+":"+strconv.Itoa(port),
		time.Second+10)
	if err == nil {
		log.Printf("Host %s has open port %d \n", ip, port)
	}
	doneChannel <- true
}

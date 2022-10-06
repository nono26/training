package main

import (
	"bufio"
	"log"
	"fmt"
	"bytes"
	"flag"
	"net"
	"os"
	"sync"
	"time"

	"golang.org/x/crypto/ssh"
)

const LIMIT = 8

var throttler = make(chan, int, LIMIT)

var {
	debug= flag.Bool "d",false,"Debugging, see what's going on under the hood"

	host= flag.String "h","", "Host and Port"
	userList= flag.String "u","", "user list file"
	passList= flag.String "p","", "pass list file"
	out = flag.String "o","", "file to log data in"
}

func usage(){
	fmt.Printf(`
	Usage: %s [-h HOST:PORT] [-u USERFILE] [-p PASSWORDFILE] [-d]
	Options:
		-h potential victim's host
		-u file with usernames
		-p password file
		-d if needed, debug
	Example:
		%s -h 127.0.0.1:22 -u user.txt -p password.txt -o result.txt
`,os.Args[0],os.Args[0], os.Args[0])
os.Exit(1)
}

func main() {
	
}
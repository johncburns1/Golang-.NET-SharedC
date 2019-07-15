.PHONY: helloworld bins clean helloworld-no-unix
default: bins-no-unix

# export to the path
export PATH := $(GOPATH)/bin:$(PATH)

# Project, test, source, and build paths
PROJECT_ROOT := github.com/johncburns1/shared-c
BUILD_DIR := C:/Users/johnc/source/repos/SharedC/SharedC/bin/Debug/netcoreapp3.0
HW_DIR := ./cmd/helloworld
MATH_DIR := ./cmd/math

# Gather source code		
ALL_SRC := $(HW_DIR)/main.go \
	$(MATH_DIR)/main.go

# programs in the /cmd dir to build
PROGS := helloworld \
	math \

# executable names
HW_WIN := helloworld.win.dll
HW_WIN_HEADER := helloworld.win.h
HW_LINUX := helloworld.linux.so
HW_LINUX_HEADER := helloworld.linux.h
HW_OSX := helloworld.osx.dylib
HW_OSX_HEADER := helloworld.osx.h

MATH_WIN := math.win.dll
MATH_WIN_HEADER := math.win.h
MATH_LINUX := math.linux.so
MATH_LINUX_HEADER := math.linux.h
MATH_OSX := math.osx.dylib
MATH_OSX_HEADER := math.osx.h

# Use dep to update and grab source
# for dependencies
dep-ensured:
	dep ensure

# HelloWorld
helloworld-windows: dep-ensured $(ALL_SRC)
	env GOOS=windows GOARCH=amd64 CGO_ENABLED=1 go build -i -v -buildmode=c-shared -o $(BUILD_DIR)/$(HW_WIN) $(HW_DIR)/*.go

helloworld-linux: dep-ensured $(ALL_SRC)
	env GOOS=linux GOARCH=amd64 CGO_ENABLED=1 go build -i -v -buildmode=c-shared -o $(BUILD_DIR)/$(HW_LINUX) $(HW_DIR)/*.go

helloworld-osx: dep-ensured $(ALL_SRC)
	env GOOS=darwin GOARCH=amd64 CGO_ENABLED=1 go build -i -v -buildmode=c-shared -o $(BUILD_DIR)/$(HW_OSX) $(HW_DIR)/*.go

helloworld: helloworld-windows \
	helloworld-linux \
	helloworld-osx

helloworld-no-unix: helloworld-windows \

helloworld-no-windows: helloworld-linux \
	helloworld-osx \

# Math
math-windows: dep-ensured $(ALL_SRC)
	env GOOS=windows GOARCH=amd64 CGO_ENABLED=1 go build -i -v -buildmode=c-shared -o $(BUILD_DIR)/$(MATH_WIN) $(MATH_DIR)/*.go

math-linux: dep-ensured $(ALL_SRC)
	env GOOS=linux GOARCH=amd64 CGO_ENABLED=1 go build -i -v -buildmode=c-shared -o $(BUILD_DIR)/$(MATH_LINUX) $(MATH_DIR)/*.go

math-osx: dep-ensured $(ALL_SRC)
	env GOOS=darwin GOARCH=amd64 CGO_ENABLED=1 go build -i -v -buildmode=c-shared -o $(BUILD_DIR)/$(MATH_OSX) $(MATH_DIR)/*.go

math: math-windows \
	math-linux \
	math-osx

math-no-unix: math-windows \

math-no-windows: math-linux \
	math-osx \

# Bins
bins: helloworld \
	math \

bins-no-unix: helloworld-no-unix \
	math-no-unix \

bins-no-windows: helloworld-no-windows \
	math-no-windows \

# Clean	
clean:
	rm -Rf bin/*

	# dll files
	rm -f $(BUILD_DIR)/$(HW_WIN)
	rm -f $(BUILD_DIR)/$(HW_LINUX)
	rm -f $(BUILD_DIR)/$(HW_OSX)

	# header files
	rm -f $(BUILD_DIR)/$(HW_WIN_HEADER)
	rm -f $(BUILD_DIR)/$(HW_LINUX_HEADER)
	rm -f $(BUILD_DIR)/$(HW_OSX_HEADER)

	# dll files
	rm -f $(BUILD_DIR)/$(MATH_WIN)
	rm -f $(BUILD_DIR)/$(MATH_LINUX)
	rm -f $(BUILD_DIR)/$(MATH_OSX)

	# header files
	rm -f $(BUILD_DIR)/$(MATH_WIN_HEADER)
	rm -f $(BUILD_DIR)/$(MATH_LINUX_HEADER)
	rm -f $(BUILD_DIR)/$(MATH_OSX_HEADER)
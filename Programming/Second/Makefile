all: build run

build: libconv.a
	gcc main.c -L. -lconv -o main

run:
	./main

libconv.a: libconv.o
	ar rcs libconv.a libconv.o

libconv.o: libconv.c
	gcc -c libconv.c -o libconv.o -std=c89

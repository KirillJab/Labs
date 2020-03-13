all: build run

build:
	gcc -c libconv.c -o libconv.o -std=c89
	ar rcs libconv.a libconv.o
	gcc main.c -L. -lconv -o main
run:
	./main
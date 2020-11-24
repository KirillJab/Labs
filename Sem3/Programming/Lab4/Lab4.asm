.model small
.stack 100h

.data

lng dw 0
pi db 100 dup(0)
inputString db 100 dup('$')

.code

PrintNumber PROC
	push bx
	push cx
	push dx

		xor cx,cx 
		PutNumberToStack:
			xor dx, dx
			mov bx, 10
			div bx
			add dx, '0'
			push dx
			inc cx
			cmp ax, 0
			jne PutNumberToStack
			
		PrintNumberFromStack:
			pop dx
			mov ah, 02h
			int 21h
			loop PrintNumberFromStack
	pop cx
	pop bx
	pop dx
	ret
PrintNumber ENDP

GetString PROC
	push ax
	push bx
	push cx

	lea di, inputString
	InputLetter:
		mov ah, 01h
		int 21h
		cmp al, 10
		je Exit
		cmp al, 13
		je Exit
		cld
		stosb
		inc	lng
		jmp InputLetter
	Exit:

	pop cx
	pop bx
	pop ax
	ret
GetString ENDP

PrefixFunc PROC
	push ax
	push bx
	push cx
	push dx
	xor ax, ax
	xor bx, bx

	cld
	mov cx, 1
	loop1:
		cmp cx, lng
		jnl Loop1Exit
		lea si, pi
		add si, cx
		sub si, 1
		lodsb
		loop2:
			cmp ax, 0
			jle loop2Exit
			lea si, inputString
			add si, cx
			lea di, inputString
			add di, ax
			cmpsb
			je loop2Exit
			lea si, pi
			add si, ax
			dec si
			lodsb
			jmp loop2
		loop2Exit:

		lea si, inputString
		add si, cx
		lea di, inputString
		add di, ax
		cmpsb
		jne else1
			inc ax
		else1:
		lea di, pi
		add di, cx
		stosb
		inc cx
		jmp loop1
	Loop1Exit:	
	pop dx
	pop cx
	pop bx
	pop ax
	ret
PrefixFunc ENDP

main:
	mov ax, @data
	mov ds, ax
	mov es, ax
	
	call GetString
	call PrefixFunc
	xor ax, ax
	lea si, pi
	add si, lng
	dec si
	lodsb

	xor dx, dx
	mov bx, lng
	sub bx, ax
	mov ax, lng
	div bx
	cmp dx, 0
	jne here
	mov ax, bx
	jmp there
	here:
	mov ax, lng
	there:
	call PrintNumber

	;mov ah, 08h
	;int 21h

	mov ax, 4c00h
	int 21h
end main
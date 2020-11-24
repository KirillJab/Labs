.model small
.stack 100h

.data

	inpStr1 db "Please, type A: $"
	inpStr2 db "Please, type B: $"
	answerStr db "The Answer is: $"
	remainderStr1 db " and $"
	remainderStr2 db " as the remainder$"
	

	leng dw 0

	esc db 27
	entr db 13
	backspace db 8
	newLineChar db 10

.code

endl PROC
	push ax
	push dx
	mov dl, newLineChar
	mov ah, 02h
	int 21h
	pop dx
	pop ax
	ret
endl ENDP

GetNumber PROC
		push bx
		push cx
		push dx

		xor bx, bx

		NumberEnterLoop:
			mov ah, 08h
			int 21h

			cmp leng, 0
			je FirstDigit
			
			cmp al, backspace
			je DeleteDigit
			
			cmp al, esc
			je DeleteNumber

			cmp al, entr
			je EndLoop

			InputDigit:
				sub al, '0'
				mov cl, al

				cmp al, 9
				ja NumberEnterLoop
				
				xor dx, dx
				mov ax, 10 
				mul bx     
				cmp dx, 0
				jne NumberEnterLoop

				xor ch, ch
				add ax, cx 
				jc NumberEnterLoop

				mov bx, ax 

				inc leng
				jmp DrawDigit

				DrawDigit:
					xor dx, dx
					mov dl, cl
					add dl, '0'
					mov ah, 02h
					int 21h


				jmp NumberEnterLoop
				
			FirstDigit:
				cmp al, '0'
				je NumberEnterLoop
				jmp InputDigit

			DeleteDigit:
				push dx

				cmp leng, 0
				je Exit

				call EraseDigit

				dec leng
				xor dx, dx	
				mov ax, bx
				mov bx, 10
				div bx
				mov bx, ax

				Exit:
				pop dx
				jmp NumberEnterLoop

			DeleteNumber:
				cmp leng, 0
				jna NumberEnterLoop
				call EraseDigit

				dec leng
				xor dx, dx	
				mov ax, bx
				mov bx, 10
				div bx
				mov bx, ax

				cmp leng, 0
				ja DeleteNumber
				jmp NumberEnterLoop
				
		EndLoop:
			call endl
			mov ax, bx
			mov leng, 0
			pop dx
			pop cx
			pop bx
		ret
GetNumber ENDP

EraseDigit PROC
	push dx
	mov dl, backspace
	mov ah, 02h
	int 21h
	mov dl, ' '
	int 21h
	mov dl, backspace
	int 21h
	pop dx
ret
EraseDigit ENDP

PrintNumber PROC
	push bx
	push cx

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
	ret
PrintNumber ENDP

	main:
		mov ax, @data
		mov ds, ax

		xor ax, ax
		xor bx, bx
		xor cx, cx
		xor dx, dx

		call endl

		lea dx, inpStr1
		mov ah, 09h
		int 21h
		call GetNumber
		mov bx, ax

		lea dx, inpStr2
		mov ah, 09h
		int 21h
		call GetNumber

		xor dx, dx
		xchg ax, bx
		div bx

		push dx
		push ax
		lea dx, AnswerStr
		mov ah, 09h
		int 21h
		pop ax
		call PrintNumber
		lea dx, remainderStr1
		mov ah, 09h
		int 21h
		pop ax
		call PrintNumber
		lea dx, remainderStr2
		mov ah, 09h
		int 21h
		call endl
		call endl
		mov ah, 08h
		int 21h

		
		
		mov ax, 4c00h
		int 21h
	end main




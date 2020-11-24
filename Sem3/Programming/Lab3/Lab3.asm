.model small
.stack 100h

.data

	inpStr1 db "Please, type A: $"
	inpStr2 db "Please, type B: $"
	answerStr db "The Answer is: $"
	remainderStr1 db " and $"
	remainderStr2 db " as the remainder$"
	

	leng dw 0
	isNegative dw 0
	limit dw 7fffh

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
		mov isNegative, 0
		xor bx, bx

		NumberEnterLoop:
			mov ah, 08h
			int 21h

			cmp leng, 0
			je FirstDigit
			
			CanErase:
			cmp al, backspace
			je DeleteDigit
			
			cmp al, esc
			jne ABitDown
			jmp DeleteNumber

			ABitDown:
			cmp al, entr
			jne InputDigit
			jmp EndLoop

			InputDigit:
				sub al, '0'
				mov cl, al

				cmp al, 9
				ja ContinueInput
				
				xor dx, dx
				mov ax, 10 
				mul bx     
				cmp dx, 0
				jne ContinueInput

				xor dx, dx
				mov dx, 7fffh
				add dx, isNegative
				mov limit, dx

				xor ch, ch
				add ax, cx
				jc ContinueInput
				cmp ax, limit
				ja ContinueInput

				mov bx, ax 

				inc leng
				xor dx, dx
				mov dl, cl
				add dl, '0'
				mov ah, 02h
				int 21h
				jmp ContinueInput
			
			ContinueInput:
				jmp NumberEnterLoop

			FirstDigit:
				cmp al, '0'
				je ContinueInput

				cmp isNegative, 1
				je CanErase
				cmp al, '-'
				jne InputDigit

				call PrintMinus
				mov isNegative, 1
				jmp ContinueInput

			DeleteDigit:
				push dx

				cmp leng, 0
				je CheckNegativity

				dec leng
				call EraseDigit
				call DivideAxByTen
				cmp leng, 0
				jmp Exit

				CheckNegativity:
				cmp isNegative, 0
				je Exit
				call EraseDigit
				mov isNegative, 0

				Exit:
				pop dx
				jmp ContinueInput


			DeleteNumber:
				push dx
				mov dx, leng
				add dx, isNegative
				mov leng, dx
				mov isNegative, 0

				DeleteNumberLoop:
				cmp leng, 0
				je ContinueInput

				dec leng
				call EraseDigit
				call DivideAxByTen

				cmp leng, 0
				ja DeleteNumberLoop
				pop dx
				jmp ContinueInput
				
		EndLoop:
			cmp leng, 0
			je ContinueInput
			call endl
			mov ax, bx
			call CheckAndAddToTwoIfNeeded
			mov leng, 0
			pop dx
			pop cx
			pop bx
		ret
GetNumber ENDP

DivideAxByTen PROC
	xor dx, dx	
	mov ax, bx
	mov bx, 10
	div bx
	mov bx, ax
	ret
DivideAxByTen ENDP

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

Check PROC
	push ax
	call PrintMinus
	mov ax, leng
	call PrintNumber 
	mov ax, isNegative
	call PrintNumber 
	call PrintMinus
	pop ax 
	ret
Check ENDP

PrintMinus PROC
	push ax
	push dx
	mov dl, '-'
	mov ah, 02h
	int 21h
	pop dx
	pop ax
	ret
PrintMinus ENDP

PrintNumber PROC
	push ax
	push bx
	push cx
	push dx
	xor cx,cx 

	cmp ax, 0
	je PutNumberToStack
	cmp isNegative, 1
	jne PutNumberToStack
	call PrintMinus
	call CheckAndInvert
	
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
	pop dx
	pop cx
	pop bx
	pop ax
	ret
PrintNumber ENDP

CheckAndAddToTwoIfNeeded PROC
	cmp isNegative, 1
	jne NotNeeded
	not ax
	add ax, 1
	NotNeeded:
	ret
CheckAndAddToTwoIfNeeded ENDP

CheckAndInvert PROC
	cmp isNegative, 1
	jne NotNeeded1
	sub ax, 1
	not ax
	NotNeeded1:
	ret
CheckAndInvert ENDP

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
	mov cx, isNegative
	mov bx, ax

	lea dx, inpStr2
	mov ah, 09h
	int 21h
	call GetNumber

	cmp bx, 8000h
	jne A
	cmp ax, 65535 
	jne A
	jmp B
	
	A:	
	xor dx, dx
	xchg ax, bx
	cwd
	idiv bx
	cmp cx, isNegative
	je NotNegative
	mov isNegative, 1
	jmp Answer
	NotNegative:
	mov isNegative, 0
	jmp Answer

	B:
	mov ax, 8000h
	mov dx, 0

	Answer:
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
	cmp cx, 0
	jne Print
	mov isNegative, 0
	Print:
	call PrintNumber
	lea dx, remainderStr2
	mov ah, 09h
	int 21h
	call endl
	call endl
	call endl
	;mov ah, 08h                   	uncomment this two lines and delete the "jmp main" line to use this program
	;int 21h						for only one calculation per program launch		

	jmp main 
	
	mov ax, 4c00h
	int 21h
end main




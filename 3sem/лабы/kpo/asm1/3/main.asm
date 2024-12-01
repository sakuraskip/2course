.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD ;прототип функции messagebox

.STACK 4096

.CONST

.DATA
myArray DD 1,3,4,7,8,0,12
myArraySize DD 7
result DD 0
STR3 DB "result: ",0
myBytes BYTE 10h,20h,30h,40h
myWords WORD 8Ah, 3Bh, 44h,5Fh,99h
myDoubles DWORD 1,2,3,4,5,6
myPointer DWORD myDoubles
STR1 DB "eax: ",0
STR2 DB "edx: ",0

.CODE 

main PROC
START : 
mov EBX, myPointer
mov eax,[EBX+4]
mov edx, [ebx+8]
add eax,30h
add edx,30h
mov STR1+4,al
mov STR2+5,dl


invoke MessageBoxA, 0,offset STR1, 0,0
invoke MessageBoxA,0,offset STR2,0,0

mov esi, offset myArray
mov ebx,0
mov ecx,7

CYCLE:
	mov eax, [esi]
	add result,eax
	add esi, 4

	cmp eax,0
	jz ifZero
	loop CYCLE
	jmp ifNotZero
invoke MessageBoxA,0,offset STR3,0,0


ifZero:
   mov ebx,0
   push 2
   call ExitProcess

ifNotZero:
   mov ebx,1
   push 3
   call ExitProcess

push - 1
call ExitProcess
main ENDP

end main
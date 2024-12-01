.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD ;прототип функции messagebox

.STACK 4096

.CONST

.DATA
MB_OK EQU 0
STR1 DB "lab 2",0
STR2 DB "result = < >",0
a1 db 4
b2 db 2
.CODE 

main PROC
START : 
mov al, a1
add al, b2
add al, 30h

mov STR1+16,al

invoke MessageBoxA, 0, offset STR2, offset STR1, 3


push - 1
call ExitProcess
main ENDP

end main
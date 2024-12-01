.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD ;прототип функции messagebox

.STACK 4096

.CONST

.DATA
MB_OK EQU 0
STR1 DB "мо€ последн€€ программа",0
STR2 DB "привет всем!",0
HW DD ?

.CODE 

main PROC
START : 
INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK


push 13
call ExitProcess
main ENDP

end main
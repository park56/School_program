import time
import os
import ctypes
import numpy as np

def cls():
    os.system('cls')
     

def gotoxy(x,y):
    ctypes.windll.kernel32.SetConsoleCursorPosition(ctypes.windll.kernel32.GetStdHandle(-11),(((y&0xFFFF)<<0x10)|(x&0xFFFF)))

block_L = np.array([[0,0,0,0],
                    [0,1,0,0],
                    [0,1,1,1],
                    [0,0,0,0]])        

        
x = 3
y = 3
                                                           
add = 0 
for i in range(1, 11): 
# #while True:
    cls()
    for j in range(0,4):
        for i in range(0,4):
            if(block_L[j,i]==1):
                gotoxy(i+x, j+y)
                print("*",end="")
            else:
                gotoxy(i+x, j+y)
                print("-",end="")

            
    # a=np.array([1,2,3])
    # print(block_L)

    # gotoxy(i, i)
    
    # add = add + i 
    # print(add)
    
    #print("haha")
    time.sleep(1)

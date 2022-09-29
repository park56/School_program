void setup() 
{
  Serial.begin(9600);
  
  pinMode(12,INPUT);
  pinMode(6,INPUT);
  digitalWrite(12, HIGH);
  digitalWrite(6, HIGH);
 
  pinMode(3,OUTPUT);
  pinMode(11,OUTPUT);
}

char flag_row1 = 0;
char flag_row2 = 0;
int row_port[2] = {12,6};
char row_flag[2][2] = {{0, 0},{0,0}};
int col_port[2] = {3,11};

void loop() 
{
  for(int j = 0; j < 2; j++)
  {
    // all col off  // 오프를 안할 시 잔상(전에 누른버튼)이 생김
    for(int i = 0; i < 2; i++)
    {
      digitalWrite(col_port[i], LOW);
    }
    
    // 2. col high
    digitalWrite(col_port[j],HIGH);
    
    // Row 
    for(int i = 0; i < 2; i++)
    {
      int row = digitalRead(row_port[i]);
      if (row == 0 && row_flag[i][j] == 0) 
      {
        row_flag[i][j] = 1;
        Serial.println("button "+ String((i*2+1*j)+1) + " down");  
      } 
      else if (row == 1 && row_flag[i][j] == 1) 
      {
        row_flag[i][j] = 0;
        Serial.println("button "+ String((i*2+1*j)+1) + " up");
      }
    }
  }
  
  delay(10);
}

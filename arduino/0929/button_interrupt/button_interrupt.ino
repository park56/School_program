void setup() 
{
  Serial.begin(9600);

  pinMode(3,INPUT);

  attachInterrupt(1, myISR,RISING);  //rising edge일때 인식
 // attachInterrupt(1, myISR, CHANGE);  // RISING FALLING 모두 인식
}

void loop() 
{
    

}

unsigned long first_time = 0;
unsigned long second_time = 0;
int diff_time = 0;

void myISR()
{
  int in_value = digitalRead(3);
  
  if(in_value = 1)
  {
    first_time = millis(); 
    //Serial.println("Rising");
  }
  else
  {
    second_time = millis();
    diff_time = second_time - first_time;
    Serial.println(diff_time);
  }

  
}

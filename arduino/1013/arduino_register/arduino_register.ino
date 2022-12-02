void setup() {
  
  Serial.begin(9600);
  //pinMode(13,OUTPUT);

  DDRB |= (0x01 << 5);

//  DDRD &= ~(0x01 << 3);


  // ---------------------------------------
  //attachInterrupt(1, myISR, CHANGE);

  DDRD &= ~(0x01 <<3); // PORTD.3 : Input Mode
  EICRA = 0x04; // exit 1
  EIMSK = 0x02;
}

void loop() {

//  unsigned char in_value = PIND;
//  int invalue = digitalRead(3);
//  if(invalue == 1)
//  {
//    PORTB |= (0x01 << 5);
//  }
//  else
//  {
//    PORTB &= ~(0x01 << 5);
//  }

//  unsigned char in_value = PIND;
//  if(in_value & (0x01 << 3))
//  {
//    PORTB |= (0x01 << 5);
//  }
//  else
//  {
//    PORTB &= ~(0x01 << 5);
//  }
//  delay(10);
  
  //digitalWrite(13,HIGH);
  //PORTB |= (0x01 << 5);
  //delay(1000);
  //digitalWrite(13,LOW);
  //PORTB &= ~(0x01 << 5);
  //delay(1000);
//    unsigned char in_value = PIND;
//    int invalue = digital_read(3);
//    if(invalue == 1)
//    {
//      PORTB |= (0x01 << 5);
//    }
//    else
//    {
//      PORTB &= ~(0x01 << 5);
//    }
}

int digital_read(int pin_num)
{
  int pin_value = 0;
  unsigned char in_value = 0;
  
  if(pin_num < 8)
  {
    DDRD &= ~(0x01 << pin_num);
    in_value = PIND;
    if(in_value & (0x01 << pin_num))
    {
      pin_value = 1;
    }
    else
    {
      pin_value = 0;
    }
  }
  else if (pin_num >= 8 && pin_num <= 13)
  {
    DDRB &= ~(0x01 << pin_num);
    in_value = PINB;
    if(in_value & (0x01 << pin_num))
    {
      pin_value = 1;
    }
    else
    {
      pin_value = 0;
    }
  }

  return pin_value;
}

void myISR()
{
//  int in_value = digitalRead(3);
//
//  if(in_value == 1)
//  {
//    PORTB |= (0x01 << 5);
//  }
//  else
//  {
//    PORTB &= ~(0x01 << 5);
//  }
}

SIGNAL(INT1_vect)
  {
    int in_value = digitalRead(3);

    if(in_value == 1)
    {
      PORTB |= (0x01 << 5);
    }
    else
    {
      PORTB &= ~(0x01 << 5);
    }
  }


#define SCL 19  // 클락
#define SDA 18  // 데이터

#define SCL_HIGH() digitalWrite(SCL,HIGH)
#define SCL_LOW() digitalWrite(SCL,LOW)

#define SDA_HIGH() digitalWrite(SDA,HIGH)
#define SDA_LOW() digitalWrite(SDA,LOW)

void setup() {
  Serial.println(9600);

  pinMode(SCL, OUTPUT);
  pinMode(SDA, OUTPUT); 
}

void loop() {

  PCF8574_set(0xff);
  delay(1000);
  PCF8574_set(0x00);
  delay(1000);
}


void i2c_start(){
    SCL_HIGH();
    SDA_HIGH();
    SDA_LOW();
}

void i2c_8bit_set(unsigned char data){
    for(int i = 0; i < 8; i++){
      if(data & 0x80 >> i){
        SDA_HIGH();9
      }
      else
      {
        SDA_LOW();
      }
      SCL_HIGH();
      SCL_LOW();
    }
}

void i2c_ack(){
    pinMode(SDA,INPUT);
    SCL_HIGH();   // 데이터 읽을 떄는 클럭을 HIGH로
    int ack_value = digitalRead(SDA);
    Serial.println(ack_value);
    pinMode(SDA,OUTPUT);
    SCL_LOW();
}

void i2c_stop(){
    SDA_LOW();
    SCL_HIGH();
    SDA_HIGH();
}

void PCF8574_set(unsigned char data){
  // Start Condition
  i2c_start();

  // Device Address
  i2c_8bit_set(0x27 << 1);

  // ACK for Device Address
  i2c_ack();

  // Data
  i2c_8bit_set(data);

  // ACK for Data
  i2c_ack();
  
  // Stop 
  i2c_stop();
}
